using AutoMapper;
using MediatR;
using PracticeShoppingApp.Application.Contracts.Presistence;
using PracticeShoppingApp.Domain.Entities;

namespace PracticeShoppingApp.Application.Features.Products.Commands
{
    public class UpdateProductRequestHandler : IRequestHandler<UpdateProductRequest>
    {
        private IProductRepository _productRepositoryAsync;
        private IMapper _mapper;
        public UpdateProductRequestHandler(IProductRepository productRepositoryAsync, IMapper mapper)
        {
            _productRepositoryAsync = productRepositoryAsync;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            {
                var productToUpdate = await _productRepositoryAsync.GetByIdAsync(request.ProdId);
                _mapper.Map(request, productToUpdate, typeof(UpdateProductRequest), typeof(Product));
                await _productRepositoryAsync.UpdateAsync(productToUpdate);
                return Unit.Value;
            }
        }

    }
}

