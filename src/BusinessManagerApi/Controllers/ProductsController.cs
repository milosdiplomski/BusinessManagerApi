using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessManager.DataAccess.UnitOfWork.Abstractions;
using BusinessManager.Shared.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BusinessManagerApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private ProductsBusinessLogic _productsBusinessLogic;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IUnitOfWork unitOfWork, ILogger<ProductsController> log)
        {
            _unitOfWork = unitOfWork;
            _logger = log;
            _productsBusinessLogic = new ProductsBusinessLogic(_unitOfWork, _logger);
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var popularDevelopers = _productsBusinessLogic.pera();
            return Ok(popularDevelopers);
        }
    }
}
