using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentProject.PurchaseOrders.Dto
{
    [AutoMap(typeof(PurchaseOrder))]
    public class PurchaseOrderDto
    {
        public decimal Price { get; set; }

        public short Quantity { get; set; }

        public string Customer { get; set; }

        public int FoodId { get; set; }

        public string FoodName { get; set; }

        public string Status { get; set; }
    }
}
