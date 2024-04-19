using AutoMapper;
using MediatR;
using PracticeShoppingApp.Application.Contracts.Presistence;
using PracticeShoppingApp.Application.Features.Orders.Dtos;

namespace PracticeShoppingApp.Application.Features.Orders.Queries
{
    public class GetOrdersForMonthRequestHandler : IRequestHandler<GetOrdersForMonthRequest, PagedOrdersForMonthDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersForMonthRequestHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<PagedOrdersForMonthDto> Handle(GetOrdersForMonthRequest request, CancellationToken cancellationToken)
        {
            var list = await _orderRepository.GetPagedOrdersForMonth(request.Date, request.Page, request.Size);
            var orders = _mapper.Map<List<OrdersForMonthDto>>(list);
            var count = await _orderRepository.GetTotalCountOfOrdersForMonth(request.Date);
            return new PagedOrdersForMonthDto() { Count = count, OrdersForMonth = orders, Page = request.Page, Size = request.Size };
        }
    }
}
