using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PracticeShoppingApp.UI.Auth;
using PracticeShoppingApp.UI;
using PracticeShoppingApp.UI.Services;
using PracticeShoppingApp.UI.Services.Contracts;
using PracticeShoppingApp.UI.Auth;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7123/") });
builder.Services.AddScoped(sp => new HttpClient(new AddHeadersDelegatingHandler(sp.GetRequiredService<ILocalStorageService>()))
{
    BaseAddress = new Uri("https://localhost:7123/")
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();


await builder.Build().RunAsync();
