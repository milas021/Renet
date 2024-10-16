﻿using Domain.Carts;
using Domain.Coupons;
using Domain.Orders;
using Domain.Orders.OrderSates;
using Domain.Payments;
using Domain.Products;
using Domain.Tokens;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Context {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option) {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductPictures { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Variant> Variants { get; set; }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStateBase> OrderStates { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Token> Tokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProcessingOrderSate>();
            modelBuilder.Entity<PreparingOrderState>();
            modelBuilder.Entity<RejectedOrderSate>();
            modelBuilder.Entity<ShippedOrderSate>();
        }

    }
}
