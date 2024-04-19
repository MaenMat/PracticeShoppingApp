using MediatR;
using PracticeShoppingApp.Application.Features.Orders.Dtos;

namespace PracticeShoppingApp.Application.Features.Orders.Queries
{
    public class GetOrdersForMonthRequest : IRequest<PagedOrdersForMonthDto>
    {
        public DateTime Date { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
