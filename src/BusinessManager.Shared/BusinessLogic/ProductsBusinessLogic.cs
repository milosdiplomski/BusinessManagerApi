using BusinessManager.DataAccess.Repositories;
using BusinessManager.DataAccess.UnitOfWork;
using BusinessManager.DataAccess.UnitOfWork.Abstractions;
using BusinessManager.Models.Models;
using BusinessManagerApi.Data.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Shared.BusinessLogic
{
    public class ProductsBusinessLogic 
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public ProductsBusinessLogic(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            try
            {
                var products = _unitOfWork.Products.GetAll().ToList();
                _unitOfWork.Complete();

                return products;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception occured in {GetType().FullName} in method {MethodBase.GetCurrentMethod().Name}", ex);
                throw;
            }
        }
    }
}
