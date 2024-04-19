namespace PracticeShoppingApp.Application.Features.Orders.Dtos
{
    public class PagedOrdersForMonthDto
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public ICollection<OrdersForMonthDto>? OrdersForMonth { get; set; }
    }
}