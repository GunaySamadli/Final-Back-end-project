using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
                
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductColorImage> ProductColorImages { get; set; }
        public DbSet<ProductMaterial> ProductMaterials { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ApplyDbSeedData(builder);
        }
        public static void ApplyDbSeedData(ModelBuilder builder)
        {
            builder.Entity<Brand>()
                .HasData(
                new Brand { Id = 1, Text = "Prices are lower than traditional luxury brands, meaning you can stock up on the pieces you love." },
                new Brand { Id = 2, Text = "Mejuri's affordable gold pieces are both timeless and of the moment." }
                );

        }



    }
}
