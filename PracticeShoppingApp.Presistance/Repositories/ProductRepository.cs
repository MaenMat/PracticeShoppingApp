using Microsoft.EntityFrameworkCore;
using PracticeShoppingApp.Application.Contracts.Presistence;
using PracticeShoppingApp.Domain.Entities;
using PracticeShoppingApp.Presistance;

namespace PracticeShoppingApp.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ShoppingAppDbContext dbContext) : base(dbContext)
        {
        }
        //public virtual async Task<Product> GetByIdAsync(Guid id)
        //{
        //    Product? t = await _dbContext.Set<Product>().FirstOrDefaultAsync(i => i.ProdId == id);
        //    return t;
        //}
    }
}
