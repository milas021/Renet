using Domain.Baskets;
using Domain.Coupons;
using Domain.Payments;
using Domain.Products;
using Domain.Tokens;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductPictures { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProductVariant> Variants { get; set; }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

        public DbSet<Token> Tokens { get; set; }

    }
}
