using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace BusinessManagerApi.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        protected ApplicationDbContext context;
        protected readonly DbSet<TEntity> dbSet;
        public GenericRepository(ApplicationDbContext ctx)
        {
            context = ctx;
            dbSet = ctx.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentException("Provided entity is null");
            }

            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Provided entity is null");
            }

            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public TEntity Get(int Id)
        {
            return context.Set<TEntity>().Find(Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Provided entity is null");
            }

            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }
    }
}
