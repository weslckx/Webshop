using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Data.Persistence.Repositories;
using Webshop.Data.Repositories;

namespace Webshop.Data.Persistence
{
    public class UnitOfWork: IUnitOfWork
    {
        //Setting my DbContext
        private readonly ShopDbContext _context;
        public IProductRepository Products { get; private set; }

        public UnitOfWork(ShopDbContext context)
        {
            this._context = context;
            Products = new ProductRepository(_context);

        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
