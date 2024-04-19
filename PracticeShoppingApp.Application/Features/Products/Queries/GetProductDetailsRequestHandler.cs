using AutoMapper;
using MediatR;
using PracticeShoppingApp.Application.Contracts.Presistence;
using PracticeShoppingApp.Application.Features.Products.Dtos;
using PracticeShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShoppingApp.Application.Features.Products.Queries
{
    public class GetProductDetailRequestHandler : IRequestHandler<GetProductDetailsRequest, GetProductDetailDto>
    {
        private readonly IProductRepository _asyncProductRepository;
        private readonly ICategoryRepository _asyncCategoryRepository;
        private readonly IMapper _mapper;
        public GetProductDetailRequestHandler(IProductRepository asyncProductRepository, ICategoryRepository asyncCategoryRepository, IMapper mapper)
        {
            _asyncProductRepository = asyncProductRepository;
            _asyncCategoryRepository = asyncCategoryRepository;
            _mapper = mapper;
        }
        public async Task<GetProductDetailDto> Handle(GetProductDetailsRequest request, CancellationToken cancellationToken)
        {
            var product = await _asyncProductRepository.GetByIdAsync(request.Id);
            var productdetailDto = _mapper.Map<GetProductDetailDto>(product);
            var category = await _asyncCategoryRepository.GetByIdAsync(product.CategoryId);
            var categoryDto = _mapper.Map<GetProductCategoryDto>(category);
            productdetailDto.Category = categoryDto;
            return productdetailDto;
        }
    }
}
