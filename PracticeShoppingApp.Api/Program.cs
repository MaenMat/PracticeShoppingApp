using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PracticeShoppingApp.Api;
//using PracticeShoppingApp.Api.Middlewares;
using PracticeShoppingApp.Application;
using PracticeShoppingApp.Application.Contracts.Presistence;
using PracticeShoppingApp.Identity;
using PracticeShoppingApp.Identity.Models;
using PracticeShoppingApp.Identity.Seeding;
using PracticeShoppingApp.Persistence.Repositories;
using PracticeShoppingApp.Presistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShoppingAppDbContext>(
                    options =>
                         options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"))
                    );
builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddApplicationServices();

builder.Services.AddCors(options => options.AddPolicy("Open",builder => {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
}));

//builder.Services.AddAutoMapper(typeof(ApplicationServiceRegistration));
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseCors("Open");

app.UseAuthorization();

app.MapControllers();

//app.UseMiddleware<ExceptionHandlerMiddleware>();

await app.ResetDatabaseAsync();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "admin", "user" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }
}

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    var applicationUser1 = new ApplicationUser
    {
        FirstName = "admin",
        LastName = "admin",
        UserName = "admin",
        Email = "admin@admin.com",
        EmailConfirmed = true
    };
    var applicationUser2 = new ApplicationUser
    {
        FirstName = "user",
        LastName = "user",
        UserName = "user",
        Email = "user@user.com",
        EmailConfirmed = true
    };

    var user1 = await userManager.FindByEmailAsync(applicationUser1.Email);
    var user2 = await userManager.FindByEmailAsync(applicationUser2.Email);

    if (user1 == null)
    {
        await userManager.CreateAsync(applicationUser1, "P@ssw0rd$");
        await userManager.AddToRoleAsync(applicationUser1, "admin");
    }
    if (user2 == null)
    {
        await userManager.CreateAsync(applicationUser2, "P@ssw0rd$");
        await userManager.AddToRoleAsync(applicationUser2, "user");
    }
}
app.Run();
