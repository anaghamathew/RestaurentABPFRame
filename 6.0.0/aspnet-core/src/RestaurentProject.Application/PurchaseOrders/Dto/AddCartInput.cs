using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentProject.PurchaseOrders.Dto
{
   public class AddCartInput
    {
        public string Customer { get; set; }
        public int FoodId { get; set; }

       
    }
}
