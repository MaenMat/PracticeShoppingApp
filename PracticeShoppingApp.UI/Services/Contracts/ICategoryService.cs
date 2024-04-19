using PracticeShoppingApp.Application.Features.Categories.Dtos;
using PracticeShoppingApp.Application.Features.Products.Dtos;
using PracticeShoppingApp.UI.ViewModels;

namespace PracticeShoppingApp.UI.Services.Contracts
{
    public interface ICategoryService 
    {
        Task<IEnumerable<CategoryViewModel>> GetAll();
        Task<CategoryViewModel> GetById(Guid id);
        Task<List<CategoryProductViewModel>> GetAllCategoriesWithProducts();
        Task<Guid> CreateCategory(CategoryViewModel categoryViewModel);
    }
}
