using Abp.Domain.Entities.Auditing;
using RestaurentProject.Foods;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentProject.PurchaseOrders
{
    [Table("PurchaseOrders")]
    public class PurchaseOrder: FullAuditedEntity
    {
        
        public string Customer { get; set; }

        public int Quantity { get; set; }
        public int FoodId { get; set; }

        public virtual Food PurchasedFood { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        public string Status { get; set; }

        public PurchaseOrder()
        {
            DateCreated = DateTime.UtcNow;
        }
    }
}
