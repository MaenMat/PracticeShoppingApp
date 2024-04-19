using AutoMapper;
using Blazored.LocalStorage;
using PracticeShoppingApp.Application.Features.Products.Commands;
using PracticeShoppingApp.Application.Features.Products.Dtos;
using PracticeShoppingApp.UI.Services.Contracts;
using PracticeShoppingApp.UI.ViewModels;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace PracticeShoppingApp.UI.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private IMapper _mapper;
        private ILocalStorageService _localStorage;

        public ProductService(HttpClient httpClient, IMapper mapper, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _mapper = mapper;
            _localStorage = localStorage;
        }
        public async Task<IEnumerable<ProductListViewModel>> GetAll()
        {
            await AddBearerToken();
            try
            {
                var ProductsList = await _httpClient.GetFromJsonAsync<IEnumerable<GetProductListDto>>("api/Product/all");
                var ProductsListVm = _mapper.Map<IEnumerable<ProductListViewModel>>(ProductsList);
                return ProductsListVm;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ProductDetailsViewModel?> GetById(Guid id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Product/{id}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return null;
                    }
                    var product = await response.Content.ReadFromJsonAsync<GetProductDetailDto>();
                    var ProductVm = _mapper.Map<ProductDetailsViewModel>(product);
                    return ProductVm;
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Guid?> CreateProduct(ProductDetailsViewModel productDetailViewModel)
        {
            await AddBearerToken();
            try
            {
                var createProductRequest = _mapper.Map<CreateProductRequest>(productDetailViewModel);
                var response = await _httpClient.PostAsJsonAsync("api/product", createProductRequest);
                if (response.IsSuccessStatusCode)
                {
                    var productId = await response.Content.ReadFromJsonAsync<Guid>();
                    return productId;
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    return Guid.Empty;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> UpdateProduct(ProductDetailsViewModel productDetailViewModel)
        {
            await AddBearerToken();
            try
            {
                var updateProductRequest = _mapper.Map<UpdateProductRequest>(productDetailViewModel);
                var response = await _httpClient.PutAsJsonAsync("api/product", updateProductRequest);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteProduct(Guid Id)
        {
            await AddBearerToken();
            var response = await _httpClient.DeleteAsync($"api/product/{Id}");
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
