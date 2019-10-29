using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using NorthwindDataService.Models;
using NorthwindDataService.Services;

namespace RawDataAssignment4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController: ControllerBase
    {
        private IDataService _dataService;

        public ProductsController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("{productId}")]
        public ActionResult<Product> GetProduct(int productId)
        {
            var product = _dataService.GetProduct(productId);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet("category/{categoryId}")]
        public ActionResult<IList<Product>> GetProductsByCategoryId(int categoryId)
        {
            var category = _dataService.GetCategory(categoryId);
            if (category == null) return NotFound(new List<Product>());
            return Ok(_dataService.GetProductByCategory(category.Id));
        }

        [HttpGet("name/{substring}")]
        public ActionResult<IList<Product>> GetProductsByName(string substring)
        {
            var products = _dataService.GetProductByName(substring);
            if (products.Count < 1) return NotFound(products);
            return Ok(products);
        }
    }
}