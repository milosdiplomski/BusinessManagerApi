using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManagerApi.Data.Repository
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        TEntity Get(int Id);
        IEnumerable<TEntity> GetAll();
    }
}
