using System.Collections.Generic;
using RawDataAssignment4._1.Models;

namespace RawDataAssignment4._1.Services
{
    public class DataService
    {
        public List<Category> GetCategories()
        {
            throw new System.NotImplementedException();
        }

        public Category GetCategory(int id)
        {
            throw new System.NotImplementedException();
        }

        public Category CreateCategory(string name, string description)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteCategory(int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateCategory(int categoryId, string updatedName, string updatedDescription)
        {
            throw new System.NotImplementedException();
        }

        public Product GetProduct(int i)
        {
            throw new System.NotImplementedException();
        }

        public List<Product> GetProductByCategory(int categoryId)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// TODO: Get products by name CONTAINS method argument
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Product> GetProductByName(string productName)
        {
            throw new System.NotImplementedException();
        }

        public Order GetOrder(int orderId)
        {
            throw new System.NotImplementedException();
        }

        public List<Order> GetOrders()
        {
            throw new System.NotImplementedException();
        }

        public List<OrderDetails> GetOrderDetailsByOrderId(int orderId)
        {
            throw new System.NotImplementedException();
        }

        public List<OrderDetails> GetOrderDetailsByProductId(int productId)
        {
            throw new System.NotImplementedException();
        }
    }
}