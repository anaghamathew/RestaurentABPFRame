using Abp.Application.Services.Dto;
/*using Abp.Collections.Extensions;*/
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
/*using Abp.Extensions;*/
using RestaurentProject.Foods.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization;
using RestaurentProject.Authorization;

namespace RestaurentProject.Foods
{
    [AbpAuthorize(PermissionNames.Pages_Owners)]
    public  class FoodAppService :RestaurentProjectAppServiceBase,IFoodAppService
    {
        private readonly IRepository<Food> _foodRepository;

        public FoodAppService(IRepository<Food> foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public FoodListDto CreateFood(CreateFoodInputDto createInput)
        {
            
            var food = _foodRepository.FirstOrDefault(p => p.Name == createInput.Name);
            if (food != null)
            {
                throw new Abp.UI.UserFriendlyException("There is already a food exist");
            }
            else
            {
                /*Food newfood = new Food { Name = createInput.Name, Description = createInput.Description, CategoryId= createInput.CategoryId };*/
                Food newfood= ObjectMapper.Map<Food>(createInput);
                _foodRepository.Insert(newfood);

                var foodmapped = ObjectMapper.Map<FoodListDto>(newfood);

                return foodmapped;
            }
        }

        public PagedResultDto<FoodListDto> GetFoodItems(FoodInputDto input)
        {
            var foodQuery = _foodRepository
                .GetAllIncluding(f => f.FoodCategory)
            .WhereIf(
                !input.Filter.IsNullOrEmpty(),
                p => p.Name.Contains(input.Filter) ||
                     p.Description.Contains(input.Filter)
            );

           var pagedResult= foodQuery.OrderBy(p => p.Name)
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount)
           
            .ToList();
            var totalcount = foodQuery.Count();
            var foodmapped = ObjectMapper.Map<List<FoodListDto>>(pagedResult);
            return new PagedResultDto<FoodListDto>(totalcount, foodmapped);
        }

        public FoodListDto GetFood(int id)
        {
           
            var foodResult = _foodRepository
               .GetAllIncluding(f => f.FoodCategory).ToList();
          List< FoodListDto> list = ObjectMapper.Map<List<FoodListDto>>(foodResult);
            return list[0];
        }

        public FoodListDto UpdateFood(CreateFoodInputDto createInput)
        {
             Food newfood= ObjectMapper.Map<Food>(createInput);
                _foodRepository.Update(newfood);

                var foodmapped = ObjectMapper.Map<FoodListDto>(newfood);

                return foodmapped;
        }

       /* public async Task Delete (int id)
        {
           Food existingFood = _foodRepository.FirstOrDefault(p => p.Id == id);
            existingFood.Remove(existingFood);

            


        }*/
        public  async Task DeleteAsync(int? id)
        {
            

            var food =  _foodRepository.FirstOrDefault(p => p.Id == id);
           await _foodRepository.DeleteAsync(food);
           
        }

        /* public async Task<IEnumerable<Food>> ListAsync()
         {
             return await _foodRepository.GetAllIncluding(f=>f.FoodCategory)
                  .WhereIf(
                 !input.Filter.IsNullOrEmpty(),
                 p => p.Name.Contains(input.Filter) ||
                      p.Description.Contains(input.Filter)
             );


         }*/
    }
}
