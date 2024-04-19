using AutoMapper;
using Blazored.LocalStorage;
using PracticeShoppingApp.UI.ViewModels;
using PracticeShoppingApp.Application.Features.Orders.Dtos;
using PracticeShoppingApp.UI.Services.Contracts;
using System.Net.Http.Json;
using PracticeShoppingApp.Application.Features.Orders.Commands;
using System.Net.Http.Headers;

namespace PracticeShoppingApp.UI.Services
{
    public class OrderService : IOrderService
    {
        private HttpClient _httpClient;
        private readonly IMapper _mapper;
        private ILocalStorageService _localStorage;
        public OrderService(IMapper mapper, HttpClient httpClient,ILocalStorageService localStorage)
        {
            _mapper = mapper;
            _httpClient = httpClient;
            _localStorage = localStorage;
        }
        public async Task<PagedOrderForMonthViewModel> GetPagedOrderForMonth(DateTime date, int page, int size)
        {
            await AddBearerToken();
            var orders = await _httpClient.GetFromJsonAsync<PagedOrdersForMonthDto>($"api/Order/getpagedordersformonth?date={date:yyyy-MM-dd}&page={page}&size={size}");
            var mappedOrders = _mapper.Map<PagedOrderForMonthViewModel>(orders);
            return mappedOrders;
        }
        public async Task<bool> PlaceOrder(PlaceOrderViewModel order)
        {
            await AddBearerToken();
            var createOrderRequest = _mapper.Map<CreateOrderRequest>(order);
            var response = await _httpClient.PostAsJsonAsync($"api/Order", createOrderRequest);
            if (response.IsSuccessStatusCode) return true;
            else return false;
        }
        public async Task<bool> DeleteOrder(Guid Id)
        {
            await AddBearerToken();
            var response = await _httpClient.DeleteAsync($"api/Order/{Id}");
            if (response.IsSuccessStatusCode) return true;
            else return false;

        }
        protected async Task AddBearerToken()
        {
            if (await _localStorage.ContainKeyAsync("token"))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _localStorage.GetItemAsync<string>("token"));
        }
    }
}

