using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace PracticeShoppingApp.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddSingleton<IEventBus, InMemoryEventBus>();
            return services;
        }
    }
}
