using Abp.Application.Services;
using RestaurentProject.PurchaseOrders.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentProject.PurchaseOrders
{
   public interface IPurchaseOrderAppService: IApplicationService
    {
        Task AddToCart(AddCartInput addCartInput);
    }
}
