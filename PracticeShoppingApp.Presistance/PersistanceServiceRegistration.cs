using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PracticeShoppingApp.Application.Contracts.Presistence;
using PracticeShoppingApp.Domain.Entities;
using PracticeShoppingApp.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShoppingApp.Presistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistanceService(this IServiceCollection services,IConfiguration configurations)
        {
            services.AddDbContext<ShoppingAppDbContext>(
                     options =>
                          options.UseSqlServer(configurations.GetConnectionString("DefaultConnectionString"))
                     );
            services.AddScoped(typeof(IAsyncRepository<>),typeof(BaseRepository<>));
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            return services;
        }
    }
}
