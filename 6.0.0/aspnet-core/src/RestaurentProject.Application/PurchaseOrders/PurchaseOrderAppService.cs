using Abp.Domain.Repositories;
using RestaurentProject.PurchaseOrders.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Application.Services.Dto;

namespace RestaurentProject.PurchaseOrders
{
  public  class PurchaseOrderAppService: RestaurentProjectAppServiceBase, IPurchaseOrderAppService
    {
        private readonly IRepository<PurchaseOrder> _purchaseOrderRepository;
        private readonly string purchaseStatus = "InCart";

        public PurchaseOrderAppService(IRepository<PurchaseOrder> purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }
        public async Task AddToCart(AddCartInput addCartInput)
        {
            var exisingFood = await _purchaseOrderRepository.FirstOrDefaultAsync(m => m.FoodId == addCartInput.FoodId);

            if (exisingFood != null)
            {
                exisingFood.Quantity++;
            }
            else
            {
                PurchaseOrder purchaseOrder = new PurchaseOrder()
                {
                    Customer = addCartInput.Customer,
                    Quantity = 1,
                    FoodId = addCartInput.FoodId,
                    Status= purchaseStatus,

                    DateCreated = DateTime.UtcNow
                };

                _purchaseOrderRepository.Insert(purchaseOrder);
                var ordermapped = ObjectMapper.Map<PurchaseOrderDto>(purchaseOrder);
            }
        }

        public  ListResultDto<PurchaseOrderDto>ViewCart(string Customer)
        {
            var foodQuery =  _purchaseOrderRepository
                .GetAllIncluding(f => f.PurchasedFood)
            .WhereIf(
               !String.IsNullOrEmpty(Customer),
                p => p.Customer== Customer
            ).Where(p=>p.Status== "InCart");

          var orders=  foodQuery.ToList();

            var purchaseOrderDto = ObjectMapper.Map<List<PurchaseOrderDto>>(orders);

            return new ListResultDto<PurchaseOrderDto>(purchaseOrderDto);
           

        }

        public decimal GetTotalPrice(string Customer)
        {
            decimal? total = decimal.Zero;
            var foodQuery = _purchaseOrderRepository
               .GetAllIncluding(f => f.PurchasedFood)
           .WhereIf(
              !String.IsNullOrEmpty(Customer),
               p => p.Customer == Customer
           ).Where(p => p.Status == "InCart");

            var orders = foodQuery.ToList();
            total = (from items in orders
                     select (int?)items.Quantity * items.PurchasedFood.Price).Sum();
            return (decimal)total;
        }
    }
}
