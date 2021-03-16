using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentProject.Categories.Dto
{
    [AutoMap(typeof(Category))]
  public  class CategoryDto: EntityDto
    {
        public string Name { get; set; }
       
        public string Description { get; set; }
    }
}
