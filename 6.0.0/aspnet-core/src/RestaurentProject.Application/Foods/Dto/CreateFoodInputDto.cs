using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentProject.Foods.Dto
{
    [AutoMapTo(typeof(Food))]
    public  class CreateFoodInputDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public short Quantity { get; set; }
    }
}
