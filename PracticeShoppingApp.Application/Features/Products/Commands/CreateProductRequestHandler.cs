using AutoMapper;
using MediatR;
using PracticeShoppingApp.Application.Contracts.Presistence;
using PracticeShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShoppingApp.Application.Features.Products.Commands
{
    public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, Guid>
    {
        private IProductRepository _productRepositoryAsync { get; set; }
        private IMapper _mapper { get; set; }
        public CreateProductRequestHandler(IProductRepository productRepositoryAsync, IMapper mapper)
        {
            _productRepositoryAsync = productRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var newProduct = _mapper.Map<Product>(request);
            var newProductAdded = await _productRepositoryAsync.AddAsync(newProduct);
            return newProductAdded.ProdId;
        }
    }
}
