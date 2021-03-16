using AutoMapper;
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
                   ;
            
        }

    }
}