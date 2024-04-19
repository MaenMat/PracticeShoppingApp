using PracticeShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShoppingApp.Application.Contracts.Presistence
{
    public interface IProductRepository : IAsyncRepository<Product>
    {

    }
}
