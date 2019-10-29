using System.Collections.Generic;
using NorthwindDataService.Models;

namespace NorthwindDataService.Services
{
    public interface IDataService
    {
        List<Category> GetCategories();
        Category GetCategory(int categoryId);
        Category CreateCategory(string name, string description);
        bool DeleteCategory(int categoryId);
        bool UpdateCategory(int categoryId, string updatedName, string updatedDescription);
        Product GetProduct(int productId);
        List<Product> GetProductByCategory(int categoryId);
        List<Product> GetProductByName(string productName);
        Order GetOrder(int orderId);
        List<Order> GetOrders();
        List<OrderDetails> GetOrderDetailsByOrderId(int orderId);
        List<OrderDetails> GetOrderDetailsByProductId(int productId);
    }
}