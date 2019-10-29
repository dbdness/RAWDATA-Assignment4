using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindDataService.Models;
using NorthwindDataService.Services;

namespace RawDataAssignment4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController: ControllerBase
    {
        private readonly IDataService _dataService;
        
        public CategoriesController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public ActionResult<IList<Category>> GetCategories()
        {
            return Ok(_dataService.GetCategories());
        }

        [HttpGet("{categoryId}")]
        public ActionResult<Category> GetCategory(int categoryId)
        {
            var category = _dataService.GetCategory(categoryId);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public ActionResult CreateCategory([FromBody] Category newCategory)
        {
            var newCat = _dataService.CreateCategory(newCategory.Name, newCategory.Description);
            if (newCat == null) return InternalServerError();
            return Created(newCat.Id.ToString(), newCat);
        }

        [HttpPut("{categoryId}")]
        public ActionResult<Category> UpdateCategory(int categoryId, [FromBody] Category updCategory)
        {
            var success = _dataService.UpdateCategory(categoryId, updCategory.Name, updCategory.Description);
            if (!success) return NotFound();
            return Ok(updCategory);
        }

        [HttpDelete("{categoryId}")]
        public ActionResult DeleteCategory(int categoryId)
        {
            var success = _dataService.DeleteCategory(categoryId);
            if (!success) return NotFound();
            return Ok(categoryId);
        }

        private StatusCodeResult InternalServerError()
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}