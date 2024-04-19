using AutoMapper;
using MediatR;
using PracticeShoppingApp.Application.Contracts.Presistence;
using PracticeShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShoppingApp.Application.Features.Categories.Commands
{
    public class CreateCategoryRequestHandler : IRequestHandler<CreateCategoryRequest,Guid>
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;
        public CreateCategoryRequestHandler(ICategoryRepository _categoryRepository, IMapper mapper)
        {
            this._categoryRepository = _categoryRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var categoryToAdd = _mapper.Map<Category>(request);
            var addedCategory = await _categoryRepository.AddAsync(categoryToAdd);
            return addedCategory.CategoryId;
        }
    }
}
