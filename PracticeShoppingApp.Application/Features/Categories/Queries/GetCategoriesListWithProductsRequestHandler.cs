using AutoMapper;
using MediatR;
using PracticeShoppingApp.Application.Contracts.Presistence;
using PracticeShoppingApp.Application.Features.Categories.Dtos;

namespace PracticeShoppingApp.Application.Features.Categories.Queries
{
    public class GetCategoriesListWithProductsRequestHandler : IRequestHandler<GetCategoriesListWithProductsRequest, List<GetCategoryProductListDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesListWithProductsRequestHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<GetCategoryProductListDto>> Handle(GetCategoriesListWithProductsRequest request, CancellationToken cancellationToken)
        {
            var list = await _categoryRepository.GetCategoriesWithProducts();
            return _mapper.Map<List<GetCategoryProductListDto>>(list);
        }
    }
}
