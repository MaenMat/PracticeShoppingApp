using AutoMapper;
using MediatR;
using PracticeShoppingApp.Application.Contracts.Presistence;
using PracticeShoppingApp.Application.Features.Categories.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShoppingApp.Application.Features.Categories.Queries
{
    public class GetCategoryByIdRequestHandler : IRequestHandler<GetCategoryByIdRequest, GetCategoryDetailsDto>
    {
        private IMapper _mapper;
        private ICategoryRepository _categoryRepository;
        public GetCategoryByIdRequestHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<GetCategoryDetailsDto> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            if (category == null) return null;
            var categoryDto = _mapper.Map<GetCategoryDetailsDto>(category);
            return categoryDto;
        }
    }
}
