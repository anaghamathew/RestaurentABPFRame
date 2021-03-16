using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RestaurentProject.Categories.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentProject.Categories
{
  public  interface ICategoryAppService: IAsyncCrudAppService<CategoryDto>
    {
        ListResultDto<CategoryDto> GetWithoutPagination();
    }
}
