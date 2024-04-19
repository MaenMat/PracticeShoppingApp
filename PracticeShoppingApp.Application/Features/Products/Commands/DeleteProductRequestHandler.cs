using AutoMapper;
using MediatR;
using PracticeShoppingApp.Application.Contracts.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShoppingApp.Application.Features.Products.Commands
{
    public class DeleteProductRequestHandler : IRequestHandler<DeleteProductRequest>
    {
        private IProductRepository _productRepositoryAsync;
        private IMapper _mapper;
        public DeleteProductRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepositoryAsync = productRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var productToDelete = await _productRepositoryAsync.GetByIdAsync(request.ProdId);
            await _productRepositoryAsync.DeleteAsync(productToDelete);
            return Unit.Value;
        }
    }

}
