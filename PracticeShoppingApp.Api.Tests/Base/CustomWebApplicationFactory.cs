﻿//using GloboTicket.TicketManagement.API.IntegrationTests.Base;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;
//using PracticeShoppingApp.Presistance;

//namespace PracticeShoppingApp.API.IntegrationTests.Base
//{
//    public class CustomWebApplicationFactory<TStartup>
//            : WebApplicationFactory<TStartup> where TStartup : class
//    {
//        protected override void ConfigureWebHost(IWebHostBuilder builder)
//        {
//            builder.ConfigureServices(services =>
//            {

//                services.AddDbContext<ShoppingAppDbContext>(options =>
//                {
//                    options.UseInMemoryDatabase("ShoppingAppDbContextInMemoryTest");
//                });

//                var sp = services.BuildServiceProvider();

//                using (var scope = sp.CreateScope())
//                {
//                    var scopedServices = scope.ServiceProvider;
//                    var context = scopedServices.GetRequiredService<ShoppingAppDbContext>();
//                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

//                    context.Database.EnsureCreated();

//                    try
//                    {
//                        Utilities.InitializeDbForTests(context);
//                    }
//                    catch (Exception ex)
//                    {
//                        logger.LogError(ex, $"An error occurred seeding the database with test messages. Error: {ex.Message}");
//                    }
//                };
//            });
//        }

//        public HttpClient GetAnonymousClient()
//        {
//            return CreateClient();
//        }
//    }
//}
