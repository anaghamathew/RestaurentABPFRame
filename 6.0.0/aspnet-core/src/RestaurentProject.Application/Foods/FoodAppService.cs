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

namespace RestaurentProject.Foods
{
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
