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
            var exisingFood = await _purchaseOrderRepository.FirstOrDefaultAsync(m =>( m.FoodId == addCartInput.FoodId) && (m.Customer==addCartInput.Customer) && (m.Status=="InCart"));

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
                p => p.Customer==Customer
            )
            .Where(p=>p.Status=="InCart");

          var orders=  foodQuery.ToList();
            Console.WriteLine("orders" + orders);
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
        public async Task IncrementQuantity(int ItemId)
        {
            var exisingFood = await _purchaseOrderRepository.FirstOrDefaultAsync(m => m.Id == ItemId);
            if (exisingFood != null)
            {
                exisingFood.Quantity++;
                _purchaseOrderRepository.Update(exisingFood);
            }
        }

        public async Task DecrementQuantity(int ItemId)
        {
            var exisingFood = await _purchaseOrderRepository.FirstOrDefaultAsync(m => m.Id == ItemId);
            if (exisingFood != null)
            {
                if (exisingFood.Quantity > 1)
                {
                    exisingFood.Quantity--;

                   await _purchaseOrderRepository.UpdateAsync(exisingFood);
                }
                else
                {
                   await _purchaseOrderRepository.DeleteAsync(exisingFood);
                }
                    
            }
        }
        public async Task EmptyCart(string Customer)
        {
            var foodQuery =  _purchaseOrderRepository
                .GetAllIncluding(f => f.PurchasedFood)
            .WhereIf(
               !String.IsNullOrEmpty(Customer),
                p => p.Customer == Customer
            ).Where(p => p.Status == "InCart");

            var orders = foodQuery.ToList();
            foreach (var item in orders)
            {
               await  _purchaseOrderRepository.DeleteAsync(item);
            }
               
        }
        public async Task ConfirmPurchase(string Customer)
        {
            var foodQuery = _purchaseOrderRepository
               .GetAllIncluding(f => f.PurchasedFood)
           .WhereIf(
              !String.IsNullOrEmpty(Customer),
               p => p.Customer == Customer
           ).Where(p => p.Status == "InCart");

            var orders = foodQuery.ToList();
            foreach (var item in orders)
            {
                item.Status = "Purchased";
                await _purchaseOrderRepository.UpdateAsync(item);
            }
        }

        public PagedResultDto<PurchaseOrderDto> GetOrderList(int SkipCount, int MaxResultCount)
        {
            var foodQuery = _purchaseOrderRepository
                .GetAllIncluding(f => f.PurchasedFood)
                .Where(p => p.Status == "Purchased");

            var pagedResult = foodQuery.OrderBy(p => p.Id)
             .Skip(SkipCount)
             .Take(MaxResultCount)

             .ToList();
            var totalcount = foodQuery.Count();
            var foodmapped = ObjectMapper.Map<List<PurchaseOrderDto>>(pagedResult);
            return new PagedResultDto<PurchaseOrderDto>(totalcount, foodmapped);
        }

    }
}
