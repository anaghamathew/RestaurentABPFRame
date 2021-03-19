using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RestaurentProject.Foods.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentProject.Foods
{
 public  interface IFoodAppService: IApplicationService
    {
        PagedResultDto<FoodListDto> GetFoodItems(FoodInputDto input);
        FoodListDto CreateFood(CreateFoodInputDto createInput);

       FoodListDto GetFood(int id);

        FoodListDto UpdateFood(CreateFoodInputDto createInput);

        Task DeleteAsync(int? id);

    }
}
