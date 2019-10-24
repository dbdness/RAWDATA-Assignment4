using Microsoft.EntityFrameworkCore;
using NorthwindDataService.Models;

namespace NorthwindDataService.DbContext
{
    public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost;database=northwind;uid=dannynielsen");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /**
             * Category
             */
            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Category>().Property(c => c.Id).HasColumnName("categoryid");
            modelBuilder.Entity<Category>().Property(c => c.Name).HasColumnName("categoryname");
            modelBuilder.Entity<Category>().Property(c => c.Description).HasColumnName("description");

            /**
             * Product
             */
            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Product>().Property(p => p.Id).HasColumnName("productid");
            modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnName("productname");
            modelBuilder.Entity<Product>().Property(p => p.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<Product>().Property(p => p.CategoryId).HasColumnName("categoryid");
            modelBuilder.Entity<Product>().Property(p => p.QuantityPerUnit).HasColumnName("quantityperunit");
            modelBuilder.Entity<Product>().Property(p => p.UnitsInStock).HasColumnName("unitsinstock");


            /**
             * Order
             */
            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<Order>().Property(o => o.Id).HasColumnName("orderid");
            modelBuilder.Entity<Order>().Property(o => o.ShipName).HasColumnName("shipname");
            modelBuilder.Entity<Order>().Property(o => o.ShipCity).HasColumnName("shipcity");
            modelBuilder.Entity<Order>().Property(o => o.Required).HasColumnName("requireddate");
            modelBuilder.Entity<Order>().Property(o => o.Date).HasColumnName("orderdate");

            /**
             * Order Details
             */
            modelBuilder.Entity<OrderDetails>().ToTable("orderdetails");
            modelBuilder.Entity<OrderDetails>().HasKey(o => new {o.OrderId, o.ProductId});
            modelBuilder.Entity<OrderDetails>().Property(o => o.OrderId).HasColumnName("orderid");
            modelBuilder.Entity<OrderDetails>().Property(o => o.Discount).HasColumnName("discount");
            modelBuilder.Entity<OrderDetails>().Property(o => o.ProductId).HasColumnName("productid");
            modelBuilder.Entity<OrderDetails>().Property(o => o.Quantity).HasColumnName("quantity");
            modelBuilder.Entity<OrderDetails>().Property(o => o.UnitPrice).HasColumnName("unitprice");
        }
    }
}