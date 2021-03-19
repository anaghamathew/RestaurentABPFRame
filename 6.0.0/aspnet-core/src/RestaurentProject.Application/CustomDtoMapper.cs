using AutoMapper;
using RestaurentProject.Categories;
using RestaurentProject.Categories.Dto;
using RestaurentProject.Foods;
using RestaurentProject.Foods.Dto;
using RestaurentProject.PurchaseOrders;
using RestaurentProject.PurchaseOrders.Dto;
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

            config.CreateMap<PurchaseOrder, PurchaseOrderDto>()
                 .ForMember(dto => dto.Price, options => options.MapFrom(input => input.PurchasedFood.Price))
                 .ForMember(dto => dto.Quantity, options => options.MapFrom(input => input.Quantity))
                   .ForMember(dto => dto.Customer, options => options.MapFrom(input => input.Customer))
                   .ForMember(dto => dto.FoodId, options => options.MapFrom(input => input.PurchasedFood.Id))
                   .ForMember(dto => dto.FoodName, options => options.MapFrom(input => input.PurchasedFood.Name))
                     .ForMember(dto => dto.Status, options => options.MapFrom(input => input.Status))
                      .ForMember(dto => dto.Id, options => options.MapFrom(input => input.Id)) ;
                  


        }

    }
}