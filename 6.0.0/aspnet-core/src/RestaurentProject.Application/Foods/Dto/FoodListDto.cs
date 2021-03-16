using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentProject.Foods.Dto
{
    [AutoMap(typeof(Food))]
    public  class FoodListDto: FullAuditedEntityDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string CategoryName { get; set; }


        public decimal Price { get; set; }

        public short Quantity { get; set; }

    }
   
}
