using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessManager.DataAccess.UnitOfWork.Abstractions;
using BusinessManager.Shared.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace BusinessManagerApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private ProductsBusinessLogic _productsBusinessLogic;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productsBusinessLogic = new ProductsBusinessLogic(_unitOfWork);
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var popularDevelopers = _productsBusinessLogic.pera();
            return Ok(popularDevelopers);
        }
    }
}
