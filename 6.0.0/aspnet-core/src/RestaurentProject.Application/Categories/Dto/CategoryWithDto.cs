using Abp.AutoMapper;
using RestaurentProject.Foods.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentProject.Categories.Dto
{
   /* [AutoMapFrom(typeof(Category))]*/
    public  class CategoryWithDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<FoodAloneDto> Foods { get; set; }
    }
}
