using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PracticeShoppingApp.Identity.Models;
namespace PracticeShoppingApp.Identity.Seeding;
public static class Seeding
{
    public static async void SeedIdentityDb(this IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();


        var roles = new[] { "admin", "user" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }

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
            await userManager.CreateAsync(applicationUser1, "P@ssw0rd$");
            await userManager.AddToRoleAsync(applicationUser1, "user");
        }
    }
}