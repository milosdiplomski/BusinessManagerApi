using BusinessManager.DataAccess.Abstractions;
using BusinessManager.Models.Models;
using BusinessManagerApi.Data;
using BusinessManagerApi.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessManager.DataAccess.Repositories
{
    public class ProductsRepository : GenericRepository<Products>, IProductsRepository
    {
        public ProductsRepository(ApplicationDbContext ctx) : base(ctx)
        {

        }

        public bool DeleteProduct(Guid id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id.Equals(id));

            product.Deleted = true;
            _context.SaveChanges();

            return true;
        }

        public IQueryable<Products> GetAllForConnectorSearch(int excludeStatusId)
        {
            return GetAll()
                .AsQueryable();
        }
    }
}
