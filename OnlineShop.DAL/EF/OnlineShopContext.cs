using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using OnlineShop.DAL.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;
using OnlineShop.DAL.Configurations;
using OnlineShop.DAL.Identity;

namespace OnlineShop.DAL.EF
{
    public class OnlineShopContext: IdentityDbContext<User>
    { 
        public OnlineShopContext() : base("OnlineShopContext", throwIfV1Schema: false) {
        }
        #region Entity Sets
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Error> ErrorSet { get; set; }
       
        #endregion


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasMany(c => c.Sizes)
            .WithMany(s => s.Products)
            .Map(t => t.MapLeftKey("ProductId")
            .MapRightKey("SizeId")
            .ToTable("ProductSize"));

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

        public static OnlineShopContext Create()
        {
            return new OnlineShopContext();
        }


    }
}
