using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PracticeShoppingApp.Identity.Models;
using System.Reflection.Emit;

namespace PracticeShoppingApp.Identity
{
    public class PracticeShoppingAppIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public PracticeShoppingAppIdentityDbContext()
        {
        }
        public PracticeShoppingAppIdentityDbContext(DbContextOptions<PracticeShoppingAppIdentityDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-18E50N6\\SQLEXPRESS;Database=PracticeShoppingAppIdentity;TrustServerCertificate=True;Trusted_Connection=True;");
        }
        
    }
}

