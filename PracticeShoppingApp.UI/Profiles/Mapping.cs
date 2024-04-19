using AutoMapper;
using PracticeShoppingApp.Application.Features.Categories.Commands;
using PracticeShoppingApp.Application.Features.Categories.Dtos;
using PracticeShoppingApp.Application.Features.Orders.Commands;
using PracticeShoppingApp.Application.Features.Orders.Dtos;
using PracticeShoppingApp.Application.Features.Products.Commands;
using PracticeShoppingApp.Application.Features.Products.Dtos;
using PracticeShoppingApp.UI.ViewModels;

namespace PracticeShoppingApp.UI.Profiles
{
    public class Mapping : Profile
    {
        public Mapping() 
        {
            CreateMap<ProductListViewModel, GetProductListDto>().ReverseMap();
            CreateMap<ProductDetailsViewModel, GetProductDetailDto>().ReverseMap();
            CreateMap<CreateProductRequest, ProductDetailsViewModel>().ReverseMap();
            CreateMap<UpdateProductRequest, ProductDetailsViewModel>().ReverseMap();
            CreateMap<CategoryViewModel, GetProductCategoryDto>().ReverseMap();
            CreateMap<GetCategoryListDto, CategoryViewModel>().ReverseMap();
            //CreateMap<CreateCategoryDto, CategoryViewModel>().ReverseMap();
            CreateMap<CategoryViewModel,CreateCategoryRequest>().ReverseMap();
            CreateMap<GetCategoryProductListDto, CategoryProductViewModel>().ReverseMap();
            CreateMap<GetCategoryProductDto, ProductNestedViewModel>().ReverseMap();
            CreateMap<PagedOrderForMonthViewModel, PagedOrdersForMonthDto>().ReverseMap();
            CreateMap<OrdersForMonthListViewModel, OrdersForMonthDto>().ReverseMap();
            CreateMap<PlaceOrderViewModel, CreateOrderRequest>().ReverseMap();
        }
    }
}
