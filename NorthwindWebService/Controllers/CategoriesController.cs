using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NorthwindDataService.Models;
using NorthwindDataService.Services;

namespace RawDataAssignment4.Controllers
{
    [ApiController]
    [Route("api/categories")]
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
    }
}