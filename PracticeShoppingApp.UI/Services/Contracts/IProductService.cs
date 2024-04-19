using PracticeShoppingApp.Application.Features.Products.Dtos;
using PracticeShoppingApp.UI.ViewModels;

namespace PracticeShoppingApp.UI.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductListViewModel>> GetAll();
        Task<ProductDetailsViewModel> GetById(Guid id);
        Task<Guid?> CreateProduct(ProductDetailsViewModel productDetailViewModel);
        Task<bool> UpdateProduct(ProductDetailsViewModel productDetailViewModel);
        Task<bool> DeleteProduct(Guid id);

    }
}
