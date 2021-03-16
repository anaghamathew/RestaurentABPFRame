using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentProject.Categories.Dto
{
  public  class CreateCategoryInput
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
