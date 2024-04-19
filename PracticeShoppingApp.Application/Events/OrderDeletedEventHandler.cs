using MediatR;
using PracticeShoppingApp.Application.Contracts.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShoppingApp.Application.Events
{
    public class OrderDeletedEventHandler : INotificationHandler<OrderDeletedEvent>
    {
        private IProductRepository _productRepository;
        public OrderDeletedEventHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task Handle(OrderDeletedEvent notification, CancellationToken cancellationToken)
        {
            var productToUpdate = await  _productRepository.GetByIdAsync(notification.ProductId);
            productToUpdate.StockQuantity = productToUpdate.StockQuantity + notification.Quantity;
            await _productRepository.UpdateAsync(productToUpdate);
        }
    }
}
