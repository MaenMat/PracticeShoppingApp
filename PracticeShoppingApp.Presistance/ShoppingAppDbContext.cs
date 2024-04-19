using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PracticeShoppingApp.Domain.Common;
using PracticeShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShoppingApp.Presistance
{
    public class ShoppingAppDbContext : DbContext
    {
        public ShoppingAppDbContext() { }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public ShoppingAppDbContext(DbContextOptions<ShoppingAppDbContext> options) : base(options) {}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-18E50N6\\SQLEXPRESS;Database=PracticeShoppingApp;Trusted_Connection=True;TrustServerCertificate=True;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShoppingAppDbContext).Assembly);

            var TechGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var FurnitureGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var FoodGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var CarsGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");
            var LaptopGuid = Guid.Parse("{B0788D3F-8083-43C1-92A4-EAC76A7C5DDE}");
            var SmartPhoneGuid = Guid.Parse("{6313149F-7137-473A-A4B5-A5571B43E6A9}");
            var SofaGuid = Guid.Parse("{BF3F3182-7E53-441A-8B7C-F6280BE284AA}");
            var PizzaGuid = Guid.Parse("{FE98F549-E791-4E9F-AC26-18C2292A2EE9}");
            var CarGuid = Guid.Parse("{FE98F549-E791-4EBF-AA26-04C2292A2EE9}");
            var ElectricCarGuid = Guid.Parse("{FE44F549-E791-4E9F-AC26-18C8892B2FE9}");
            var BurgerGuid = Guid.Parse("{A0098D2F-8003-43C1-92A4-BEC76A7C5DDE}");
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = TechGuid,
                Name = "Tech"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = FurnitureGuid,
                Name = "Furniture"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = FoodGuid,
                Name = "Food"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = CarsGuid,
                Name = "Cars"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProdId = LaptopGuid,
                Name = "Laptop",
                Price = 1000,
                StockQuantity = 15,
                Description = "High-performance laptop with the latest technology.",
                ImageUrl = "https://example.com/laptop.jpg",
                CategoryId = TechGuid 
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProdId = SmartPhoneGuid,
                Name = "Smartphone",
                Price = 800,
                StockQuantity = 30,
                Description = "Top-of-the-line smartphone with advanced features.",
                ImageUrl = "https://example.com/smartphone.jpg",
                CategoryId = TechGuid 
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProdId = PizzaGuid,
                Name = "Pizza",
                Price = 10,
                StockQuantity = 100,
                Description = "Delicious pizza with a variety of toppings.",
                ImageUrl = "https://example.com/pizza.jpg",
                CategoryId = FoodGuid
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProdId = BurgerGuid,
                Name = "Burger",
                Price = 8,
                StockQuantity = 100,
                Description = "Juicy burger with fresh ingredients.",
                ImageUrl = "https://example.com/burger.jpg",
                CategoryId = FoodGuid 
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProdId = SofaGuid,
                Name = "Sofa",
                Price = 500,
                StockQuantity = 10,
                Description = "Comfortable sofa for your living room.",
                ImageUrl = "https://example.com/sofa.jpg",
                CategoryId = FurnitureGuid 
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProdId = CarGuid,
                Name = "Car",
                Price = 30000,
                StockQuantity = 7,
                Description = "Luxury car with advanced features and performance.",
                ImageUrl = "https://example.com/car.jpg",
                CategoryId = CarsGuid 
            });
           
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProdId = ElectricCarGuid,
                Name = "Electric Car",
                Price = 50000,
                StockQuantity = 9,
                Description = "Environmentally friendly electric car with cutting-edge technology.",
                ImageUrl = "https://example.com/electric_car.jpg",
                CategoryId = CarsGuid 
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = Guid.Parse("{7E94BC5B-71A5-4C8C-BC3B-71BB7976237E}"),
                ProductId = PizzaGuid,
                OrderTotal = 400,
                OrderPaid = true,
                OrderPlaced = new DateTime(2023, 01, 01),
                UserId = Guid.Parse("{A441EB40-9636-4EE6-BE49-A66C5EC1330B}")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = Guid.Parse("{86D3A045-B42D-4854-8150-D6A374948B6E}"),
                ProductId = CarGuid,
                OrderTotal = 135,
                OrderPaid = true,
                OrderPlaced = new DateTime(2023, 01, 02),
                UserId = Guid.Parse("{AC3CFAF5-34FD-4E4D-BC04-AD1083DDC340}")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = Guid.Parse("{771CCA4B-066C-4AC7-B3DF-4D12837FE7E0}"),
                ProductId =SofaGuid,
                OrderTotal = 85,
                OrderPaid = true,
                OrderPlaced = new DateTime(2023, 01, 03),
                UserId = Guid.Parse("{D97A15FC-0D32-41C6-9DDF-62F0735C4C1C}")
            });
                
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastUpdatedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
