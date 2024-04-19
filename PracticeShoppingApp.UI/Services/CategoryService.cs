using AutoMapper;
using Blazored.LocalStorage;
using PracticeShoppingApp.Application.Features.Categories;
using PracticeShoppingApp.Application.Features.Categories.Commands;
using PracticeShoppingApp.Application.Features.Categories.Dtos;
using PracticeShoppingApp.UI.Services.Contracts;
using PracticeShoppingApp.UI.ViewModels;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace PracticeShoppingApp.UI.Services
{
    public class CategoryService : ICategoryService
    {
        private HttpClient _httpClient;
        private IMapper _mapper;
        private ILocalStorageService _localStorage;
        public CategoryService(HttpClient httpClient, IMapper mapper, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _mapper = mapper;
            _localStorage = localStorage;
        }
        public async Task<IEnumerable<CategoryViewModel>> GetAll()
        {
            //await AddBearerToken();
            try
            {
                var CategoryListDto = await _httpClient.GetFromJsonAsync<List<GetCategoryListDto>>("api/Category/all");
                var CategoryList = _mapper.Map<List<CategoryViewModel>>(CategoryListDto);
                return CategoryList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<CategoryViewModel> GetById(Guid id)
        {
            //await AddBearerToken();
            try
            {
                var Category = await _httpClient.GetFromJsonAsync<GetCategoryDetailsDto>($"api/Product/{id}");
                var categoryViewModel = _mapper.Map<CategoryViewModel>(Category);
                return categoryViewModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<CategoryProductViewModel>> GetAllCategoriesWithProducts()
        {
            //await AddBearerToken();
            var allCategories = await _httpClient.GetFromJsonAsync<List<GetCategoryProductListDto>>($"api/category/allwithproducts");
            var mappedCategories = _mapper.Map<IEnumerable<CategoryProductViewModel>>(allCategories);
            return mappedCategories.ToList();
        }
        public async Task<Guid> CreateCategory(CategoryViewModel categoryViewModel)
        {
            //await AddBearerToken();
            try
            {
                //ApiResponse<CategoryDto> apiResponse = new ApiResponse<CategoryDto>();
                var createCategoryRequest = _mapper.Map<CreateCategoryRequest>(categoryViewModel);
                var response = await _httpClient.PostAsJsonAsync("api/category", createCategoryRequest);
                if (response.IsSuccessStatusCode)
                {
                    var CategoryId = await response.Content.ReadFromJsonAsync<Guid>();
                    return CategoryId;
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
        protected async Task AddBearerToken()
        {
            if (await _localStorage.ContainKeyAsync("token"))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _localStorage.GetItemAsync<string>("token"));
        }
    }
}
