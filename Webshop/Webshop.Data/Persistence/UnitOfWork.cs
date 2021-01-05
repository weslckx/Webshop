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

        public ICustomerRepository Customers { get; private set; }

        public IOrderRepository Orders { get; private set; }

        public IOrderLinesRepository OrderLines { get; private set; }


        public UnitOfWork(ShopDbContext context)
        {
            this._context = context;
            Products = new ProductRepository(_context);
            Customers = new CustomerRepository(_context);
            Orders = new OrderRepository(_context);
            OrderLines = new OrderLinesRepository(_context);

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
