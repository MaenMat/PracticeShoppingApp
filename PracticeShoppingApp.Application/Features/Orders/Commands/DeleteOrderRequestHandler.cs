using MediatR;
using PracticeShoppingApp.Application.Contracts.Presistence;
using PracticeShoppingApp.Application.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShoppingApp.Application.Features.Orders.Commands
{
    public class DeleteOrderRequestHandler : IRequestHandler<DeleteOrderRequest>
    {
        private readonly IOrderRepository _orderRepository;
        private IMediator _mediator;

        public DeleteOrderRequestHandler(IOrderRepository orderRepository, IMediator mediator)
        {
             _orderRepository = orderRepository;
            _mediator = mediator;
        }
        public async Task<Unit> Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            var orderToDelete = await _orderRepository.GetByIdAsync(request.OrderId);
            if (orderToDelete != null)
            {
                var orderDeleteEvent = new OrderDeletedEvent() { ProductId = orderToDelete.ProductId, Quantity = orderToDelete.Quantity };
                await _orderRepository.DeleteAsync(orderToDelete);
                await _mediator.Publish(orderDeleteEvent);
                return Unit.Value;
            }
            else throw new Exception();
           
        }
    }
}
