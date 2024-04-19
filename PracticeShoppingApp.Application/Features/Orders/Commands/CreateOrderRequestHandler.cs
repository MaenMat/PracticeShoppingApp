using AutoMapper;
using MediatR;
using PracticeShoppingApp.Application.Contracts.Presistence;
using PracticeShoppingApp.Application.Events;
using PracticeShoppingApp.Domain.Entities;

namespace PracticeShoppingApp.Application.Features.Orders.Commands
{
    public class CreateOrderRequestHandler : IRequestHandler<CreateOrderRequest, CreateOrderResponse>
    {
        private IMapper _mapper { get; set; }
        private IOrderRepository _orderRepository { get; set; }
        private IProductRepository _productRepository { get; set; }
        private IMediator _mediator { get; set; }
        public CreateOrderRequestHandler(IMapper mapper,IOrderRepository orderRepository,
            IProductRepository productRepository, IMediator mediator)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _mediator = mediator;
        }
        public async Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var response = new CreateOrderResponse();
            var product = await _productRepository.GetByIdAsync(request.ProductId);
            if (product == null)
            {
                response.Success = false;
                response.ValidationErrors.Add("No Product Found");
                return response;
            }
            if (product.StockQuantity < request.Quantity || product.StockQuantity - request.Quantity < 0)
            {
                response.Success = false;
                response.ValidationErrors.Add("No sufficient quantity");
                return response;
            }
            var newOrder = _mapper.Map<Order>(request);
            newOrder.OrderTotal = product.Price * newOrder.Quantity;
            newOrder.OrderPlaced = DateTime.Now;
            var newOrderAdded = await _orderRepository.AddAsync(newOrder);
            if (newOrderAdded != null)
            {
                response.Success = true;
                var orderPlacedEvent = new OrderPlacedEvent() { ProdId = request.ProductId, Qty = request.Quantity};
                _mediator.Publish(orderPlacedEvent);
            }
            else
            {
                response.Success = false;
                response.Message = "Something wrong happened";
            }
            return response;
        }
    }
}
