using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using RestaurentProject.Categories.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentProject.Categories
{
    public class CategoryAppService : AsyncCrudAppService<Category,CategoryDto,int>,ICategoryAppService
    {

        private readonly IRepository<Category> _categoryRepository;
       
        public CategoryAppService(IRepository<Category> repository)
       : base(repository)
        {
            _categoryRepository = repository;
        }

       

       
        public  ListResultDto<CategoryDto>GetWithoutPagination()
        {
            var categories =  _categoryRepository.GetAll().ToList();
            var categoryDto = ObjectMapper.Map<List< CategoryDto > >(categories);

            return new ListResultDto<CategoryDto>(categoryDto);
        }


        public List<CategoryWithDto> GetCategorywithFoods()
        {
          var categories=  _categoryRepository.GetAllIncluding(
                c => c.Food).ToList();
            var categoriesDto = ObjectMapper.Map<List<CategoryWithDto>>(categories);
           
            return categoriesDto;
        }
        /* private readonly IRepository<Category> _categoryRepository;

public CategoryAppService(IRepository<Category> categoryRepository)
{
    _categoryRepository = categoryRepository;
}

public void CreateCategory(CreateCategoryInput input)
{
    var category = _categoryRepository.FirstOrDefault(p => p.Name == input.Name);
    if (category != null)
    {
        throw new Abp.UI.UserFriendlyException("There is already a category exist");
    }
    else
    {
        category = new Category { Name = input.Name, Description = input.Description };
        _categoryRepository.Insert(category);
    }

}*/
    }
}
