using AutoMapper;
using MediatR;
using PracticeShoppingApp.Application.Contracts.Presistence;
using PracticeShoppingApp.Application.Features.Categories.Dtos;

namespace PracticeShoppingApp.Application.Features.Categories.Queries
{
    public class GetCategoriesListRequestHandler : IRequestHandler<GetCategoriesListRequest, List<GetCategoryListDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesListRequestHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<GetCategoryListDto>> Handle(GetCategoriesListRequest request, CancellationToken cancellationToken)
        {
            var allCategories = (await _categoryRepository.GetAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<GetCategoryListDto>>(allCategories);
        }
    }
}
