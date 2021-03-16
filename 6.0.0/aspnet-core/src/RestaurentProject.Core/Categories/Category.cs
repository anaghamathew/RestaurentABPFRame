using Abp.Domain.Entities;
using RestaurentProject.Foods;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentProject.Categories

{
    [Table("Categories")]
    public class Category : Entity
    {


        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public virtual DateTime CreatedDate { get; set; }

        public IList<Food> Food { get; set; } = new List<Food>();
        public Category()
        {
            CreatedDate = DateTime.UtcNow;
        }
    }
}
