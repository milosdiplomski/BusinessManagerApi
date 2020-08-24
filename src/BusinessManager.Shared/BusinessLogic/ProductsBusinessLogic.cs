using BusinessManager.DataAccess.Repositories;
using BusinessManager.DataAccess.UnitOfWork;
using BusinessManager.DataAccess.UnitOfWork.Abstractions;
using BusinessManager.Models.Models;
using BusinessManagerApi.Data.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public IEnumerable<Clients> pera()
        {
            _logger.LogInformation("pera method started");

             throw new Exception("An unexpected exception occured");
            //try
            //{
            //    return _unitOfWork.Clients.GetAll().ToList();
            //}
            //catch(Exception ex)
            //{
            //    throw new Exception("An unexpected exception occured", ex.InnerException);
            //}
        }
    }
}
