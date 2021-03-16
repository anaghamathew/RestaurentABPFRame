using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using RestaurentProject.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentProject.Foods
{
    [Table("Foods")]
   public  class Food: FullAuditedEntity
    {
        [Required]
         public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [System.ComponentModel.DisplayName("Price (Rs.)")]
        public decimal Price { get; set; }

        public short Quantity { get; set; }

        public int CategoryId { get; set; }
        public virtual Category FoodCategory { get; set; }
    }
}
