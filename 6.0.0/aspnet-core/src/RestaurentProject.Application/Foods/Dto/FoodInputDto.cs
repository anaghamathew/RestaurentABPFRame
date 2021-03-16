using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentProject.Foods.Dto
{
 public class FoodInputDto: PagedResultRequestDto
      {
          public string Filter { get; set; }

      }
}
