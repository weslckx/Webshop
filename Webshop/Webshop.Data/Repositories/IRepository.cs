using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.Data.Repositories
{
   public interface IRepository<TEntity> where TEntity : class
    {
        //Getting items
        TEntity Get(int id);
        //IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAll();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        //Adding item
        void Add(TEntity entity);

        //Removing item
        void Remove(TEntity entity);




    }
}
 