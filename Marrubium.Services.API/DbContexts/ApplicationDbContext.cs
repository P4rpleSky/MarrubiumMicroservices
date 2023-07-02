using Marrubium.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Marrubium.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                ProductId = 1,
                Name = "Cream with retinol",
                Price = 1000,
                ProductTypes = JsonConvert.SerializeObject(new List<string> { "lotion" }),
                Functions = JsonConvert.SerializeObject(new List<string> { "rejuvenating", "restoring" }),
                SkinTypes = JsonConvert.SerializeObject(new List<string> { "soft" }),
                ImageUrl = "https://images.bsite.net/products/1_1.png"
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                ProductId = 2,
                Name = "Lotion with centella",
                Price = 1500,
                ProductTypes = JsonConvert.SerializeObject(new List<string> { "Serum" }),
                Functions = JsonConvert.SerializeObject(new List<string> { "rejuvenating" }),
                SkinTypes = JsonConvert.SerializeObject(new List<string> { "soft", "sensitive" }),
                ImageUrl = "https://images.bsite.net/products/1_2.png"
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                ProductId = 3,
                Name = "Serum with green tea",
                Price = 1200,
                ProductTypes = JsonConvert.SerializeObject(new List<string> { "serum" }),
                Functions = JsonConvert.SerializeObject(new List<string> { "restoring" }),
                SkinTypes = JsonConvert.SerializeObject(new List<string> { "soft" }),
                ImageUrl = "https://images.bsite.net/products/1_3.png"
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                ProductId = 4,
                Name = "Serum with wormwood",
                Price = 1600,
                ProductTypes = JsonConvert.SerializeObject(new List<string> { "serum" }),
                Functions = JsonConvert.SerializeObject(new List<string> { "restoring" }),
                SkinTypes = JsonConvert.SerializeObject(new List<string> { "soft" }),
                ImageUrl = "https://images.bsite.net/products/1_4.png"
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                ProductId = 5,
                Name = "Scrub with vanilla",
                Price = 900,
                ProductTypes = JsonConvert.SerializeObject(new List<string> { "cleaning" }),
                Functions = JsonConvert.SerializeObject(new List<string> { "rejuvenating", "restoring" }),
                SkinTypes = JsonConvert.SerializeObject(new List<string> { "soft", "sensitive" }),
                ImageUrl = "https://images.bsite.net/products/2_1.png"
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                ProductId = 6,
                Name = "Under-eye cream",
                Price = 2000,
                ProductTypes = JsonConvert.SerializeObject(new List<string> { "lotion" }),
                Functions = JsonConvert.SerializeObject(new List<string> { "rejuvenating", "restoring" }),
                SkinTypes = JsonConvert.SerializeObject(new List<string> { "sensitive" }),
                ImageUrl = "https://images.bsite.net/products/2_2.png"
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                ProductId = 7,
                Name = "Cream with mint",
                Price = 1000,
                ProductTypes = JsonConvert.SerializeObject(new List<string> { "lotion" }),
                Functions = JsonConvert.SerializeObject(new List<string> { "rejuvenating" }),
                SkinTypes = JsonConvert.SerializeObject(new List<string> { "soft", "sensitive" }),
                ImageUrl = "https://images.bsite.net/products/2_3.png"
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                ProductId = 8,
                Name = "Clay mask with matcha",
                Price = 800,
                ProductTypes = JsonConvert.SerializeObject(new List<string> { "mask" }),
                Functions = JsonConvert.SerializeObject(new List<string> { "restoring" }),
                SkinTypes = JsonConvert.SerializeObject(new List<string> { "sensitive" }),
                ImageUrl = "https://images.bsite.net/products/2_4.png"
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                ProductId = 9,
                Name = "The handle of the shovel",
                Price = 500,
                ProductTypes = JsonConvert.SerializeObject(new List<string> { "mask" }),
                Functions = JsonConvert.SerializeObject(new List<string> { "restoring" }),
                SkinTypes = JsonConvert.SerializeObject(new List<string> { "rough" }),
                ImageUrl = "https://images.bsite.net/products/3_1.png"
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                ProductId = 10,
                Name = "Garage",
                Price = 10000,
                ProductTypes = JsonConvert.SerializeObject(new List<string> { "cleaning" }),
                Functions = JsonConvert.SerializeObject(new List<string> { "rejuvenating", "restoring" }),
                SkinTypes = JsonConvert.SerializeObject(new List<string> { "rough" }),
                ImageUrl = "https://images.bsite.net/products/3_2.png"
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                ProductId = 11,
                Name = "Russian hotdog",
                Price = 50,
                ProductTypes = JsonConvert.SerializeObject(new List<string> { "serum" }),
                Functions = JsonConvert.SerializeObject(new List<string> { "rejuvenating", "restoring" }),
                SkinTypes = JsonConvert.SerializeObject(new List<string> { "rough" }),
                ImageUrl = "https://images.bsite.net/products/3_3.png"
            });
        }
    }
}
