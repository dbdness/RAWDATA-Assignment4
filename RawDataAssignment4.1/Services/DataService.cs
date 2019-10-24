using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RawDataAssignment4._1.Models;

namespace RawDataAssignment4._1.Services
{
    public class DataService
    {
        public List<Category> GetCategories()
        {
            using var db = new DatabaseContext();
            return db.Categories.ToList();
        }

        public Category GetCategory(int categoryId)
        {
            using var db = new DatabaseContext();
            return db.Categories.Find(categoryId);
        }

        public Category CreateCategory(string name, string description)
        {
            using var db = new DatabaseContext();
            var newId = db.Categories.Max(c => c.Id) + 1;
            Category newCategory = new Category()
            {
                Id = newId,
                Name = name,
                Description = description
            };
            db.Categories.Add(newCategory);

            try
            {
                db.SaveChanges();
                return db.Categories.Find(newId);
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public bool DeleteCategory(int categoryId)
        {
            using var db = new DatabaseContext();

            var category = db.Categories.Find(categoryId);
            if (category == null) return false;

            try
            {
                db.Categories.Remove(category);
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }

        public bool UpdateCategory(int categoryId, string updatedName, string updatedDescription)
        {
            using var db = new DatabaseContext();

            var category = db.Categories.Find(categoryId);
            if (category == null) return false;

            category.Name = updatedName;
            category.Description = updatedDescription;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }

        public Product GetProduct(int productId)
        {
            using var db = new DatabaseContext();
            return db.Products
                .Include(p => p.Category).ToList()
                .Find(p => p.Id == productId);
        }

        public List<Product> GetProductByCategory(int categoryId)
        {
            using var db = new DatabaseContext();
            return db.Products.Include(p => p.Category).ToList()
                .FindAll(p => p.CategoryId == categoryId);
        }

        public List<Product> GetProductByName(string productName)
        {
            using var db = new DatabaseContext();
            return db.Products.Where(p => p.Name.Contains(productName)).ToList();
        }

        public Order GetOrder(int orderId)
        {
            using var db = new DatabaseContext();
            var order = new Order();

            return db.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .ThenInclude(p => p.Category).ToList()
                .Find(o => o.Id == orderId);
        }

        public List<Order> GetOrders()
        {
            using var db = new DatabaseContext();
            return db.Orders.ToList();
        }

        public List<OrderDetails> GetOrderDetailsByOrderId(int orderId)
        {
            using var db = new DatabaseContext();
            return db.OrderDetails.
                Include(od => od.Order).
                Include(od => od.Product)
                .ToList()
                .FindAll(od => od.OrderId == orderId);
        }

        public List<OrderDetails> GetOrderDetailsByProductId(int productId)
        {
            using var db = new DatabaseContext();
            return db.OrderDetails.Include(od => od.Order)
                .Where(od => od.ProductId == productId)
                .ToList();
        }
    }
}