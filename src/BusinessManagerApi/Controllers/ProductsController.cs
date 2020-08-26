using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BusinessManager.DataAccess.UnitOfWork.Abstractions;
using BusinessManager.Shared.BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BusinessManagerApi.Controllers
{

    [Produces("application/json")]
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

        /// <summary>
        /// Gets all products from database.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>List of products</returns>
        /// <response code="200">Returns the list of items</response>
        
        [Route("GetProducts")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetProducts()
        {
            var popularDevelopers = _productsBusinessLogic.pera();
            return Ok(popularDevelopers);
        }
    }
}
