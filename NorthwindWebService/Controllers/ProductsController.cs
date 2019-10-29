using Microsoft.AspNetCore.Mvc;
using NorthwindDataService.Services;

namespace RawDataAssignment4.Controllers
{
    public class ProductsController: ControllerBase
    {
        private IDataService _dataService;

        public ProductsController(IDataService dataService)
        {
            _dataService = dataService;
        }
    }
}