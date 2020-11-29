using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Webshop.Data.Repositories;

namespace Webshop.Data.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        //DI -> not my DbContext
        protected readonly DbContext context;

        public Repository(ShopDbContext context)
        {
            this.context = context;
        }

        //Get Items
        public TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        // Add Item
        public void Add(TEntity entity)
        {
            context.Add(entity);
        }


        //Find Item
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate);
        }

     
        //Remove Item
        public void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }
    }
}
