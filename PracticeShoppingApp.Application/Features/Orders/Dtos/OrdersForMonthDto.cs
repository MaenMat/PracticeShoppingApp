namespace PracticeShoppingApp.Application.Features.Orders.Dtos
{
    public class OrdersForMonthDto
    {
        public Guid OrderId { get; set; }
        public int OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
    }
}