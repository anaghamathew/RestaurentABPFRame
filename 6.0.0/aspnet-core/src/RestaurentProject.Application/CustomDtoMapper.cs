using AutoMapper;
using RestaurentProject.Categories;
using RestaurentProject.Categories.Dto;
using RestaurentProject.Foods;
using RestaurentProject.Foods.Dto;
using System;

namespace RestaurentProject
{
    internal class CustomDtoMapper
    {
        /*public static Action<IMapperConfigurationExpression> CreateMappings */




        public static void CreateMappings(IMapperConfigurationExpression config)
        {

            config.CreateMap<Food, FoodListDto>()
                 .ForMember(dto => dto.CategoryName, options => options.MapFrom(input => input.FoodCategory.Name))
                 .ForMember(dto => dto.Name, options => options.MapFrom(input => input.Name))
                   .ForMember(dto => dto.Description, options => options.MapFrom(input => input.Description))
                   .ForMember(dto => dto.Quantity, options => options.MapFrom(input => input.Quantity))
                   .ForMember(dto => dto.Price, options => options.MapFrom(input => input.Price))
                    .ForMember(dto => dto.CategoryId, options => options.MapFrom(input => input.CategoryId));

            config.CreateMap<Food, FoodAloneDto>()
                 .ForMember(dto => dto.Name, options => options.MapFrom(input => input.Name))
                   .ForMember(dto => dto.Id, options => options.MapFrom(input => input.Id))
                    .ForMember(dto => dto.Price, options => options.MapFrom(input => input.Price))
                     .ForMember(dto => dto.Quantity, options => options.MapFrom(input => input.Quantity))
                        .ForMember(dto => dto.Description, options => options.MapFrom(input => input.Description))
                     ;

            config.CreateMap<Category, CategoryWithDto>()
                 .ForMember(dto => dto.Id, options => options.MapFrom(input => input.Id))
                  .ForMember(dto => dto.Name, options => options.MapFrom(input => input.Name))
                   .ForMember(dto => dto.Foods, options => options.MapFrom(input => input.Food));


        }

    }
}