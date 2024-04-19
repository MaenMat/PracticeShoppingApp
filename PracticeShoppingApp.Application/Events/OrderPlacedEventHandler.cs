using MediatR;
using PracticeShoppingApp.Application.Contracts.Presistence;

namespace PracticeShoppingApp.Application.Events
{
    public class OrderPlacedEventHandler : INotificationHandler<OrderPlacedEvent>
    {
        private readonly IProductRepository _productRepository;

        public OrderPlacedEventHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task Handle(OrderPlacedEvent notification, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(notification.ProdId);
            product.StockQuantity = product.StockQuantity - notification.Qty;
            await _productRepository.UpdateAsync(product);
            return;
        }
    }

}
