using Microsoft.AspNetCore.Mvc;
using NorthwindDataService.Services;

namespace RawDataAssignment4.Controllers
{
    public class CategoriesController: ControllerBase
    {
        private IDataService _dataService;
        
        public CategoriesController(IDataService dataService)
        {
            _dataService = dataService;
        }
        
        
    }
}