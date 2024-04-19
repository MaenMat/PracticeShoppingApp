using AutoMapper;
using PracticeShoppingApp.Application.Features.Categories;
using PracticeShoppingApp.Application.Features.Categories.Commands;
using PracticeShoppingApp.Application.Features.Categories.Dtos;
using PracticeShoppingApp.Application.Features.Orders.Commands;
using PracticeShoppingApp.Application.Features.Orders.Dtos;
using PracticeShoppingApp.Application.Features.Products.Commands;
using PracticeShoppingApp.Application.Features.Products.Dtos;
using PracticeShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShoppingApp.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, GetProductListDto>().ReverseMap();
            CreateMap<Product, GetProductDetailDto>().ReverseMap();
            //CreateMap<Product, CreateProductDto>().ReverseMap();
            //CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetCategoryProductDto>().ReverseMap();
            CreateMap<Product, CreateProductRequest>().ReverseMap();
            CreateMap<Product, UpdateProductRequest>().ReverseMap();

            CreateMap<Category, GetProductCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryListDto>().ReverseMap();
            CreateMap<Category, GetCategoryProductListDto>().ReverseMap();
            CreateMap<Category, CreateCategoryRequest>().ReverseMap();
            CreateMap<Category, GetCategoryDetailsDto>().ReverseMap();

            CreateMap<Order, OrdersForMonthDto>().ReverseMap();
            CreateMap<Order, CreateOrderRequest>().ReverseMap();
        }
    }
}
