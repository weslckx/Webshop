using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Webshop.Data.Repositories
{
   public interface IRepository<TEntity> where TEntity : class
    {
        //Getting items
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        //Adding item
        void Add(TEntity entity);

        //Removing item
        void Remove(TEntity entity);




    }
}
 