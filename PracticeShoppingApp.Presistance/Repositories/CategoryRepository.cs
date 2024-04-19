using Microsoft.EntityFrameworkCore;
using PracticeShoppingApp.Application.Contracts.Presistence;
using PracticeShoppingApp.Domain.Entities;
using PracticeShoppingApp.Presistance;

namespace PracticeShoppingApp.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ShoppingAppDbContext dbContext) : base(dbContext)
        {
        }
        public Task<List<Category>> GetCategoriesWithProducts()
        {
            var allCategories = _dbContext.Categories.Include(x => x.Products).ToListAsync();
            return allCategories;
        }
    }
}
