using BusinessManager.DataAccess.Repositories;
using BusinessManager.DataAccess.UnitOfWork;
using BusinessManager.DataAccess.UnitOfWork.Abstractions;
using BusinessManager.Models.Models;
using BusinessManagerApi.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessManager.Shared.BusinessLogic
{
    public class ProductsBusinessLogic 
    {

        private readonly IUnitOfWork _unitOfWork;

        public ProductsBusinessLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Clients> pera()
        {
            return _unitOfWork.Clients.GetAll().ToList();
        }
    }
}
