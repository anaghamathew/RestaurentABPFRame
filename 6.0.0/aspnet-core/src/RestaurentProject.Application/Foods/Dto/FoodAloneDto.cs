using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentProject.Foods.Dto
{
   /* [AutoMapFrom(typeof(Food))]*/
    public  class FoodAloneDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public short Quantity { get; set; }

        public string Description { get; set; }



    }
}
