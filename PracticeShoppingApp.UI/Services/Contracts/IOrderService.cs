using PracticeShoppingApp.UI.ViewModels;

namespace PracticeShoppingApp.UI.Services.Contracts
{
    public interface IOrderService
    {
        Task<PagedOrderForMonthViewModel> GetPagedOrderForMonth(DateTime date, int page, int size);
        Task<bool> DeleteOrder(Guid Id);
        Task<bool> PlaceOrder(PlaceOrderViewModel order);
    }
}
