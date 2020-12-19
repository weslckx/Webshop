using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Data.Repositories;
using Webshop.Domain.Models;
using System.Linq;

namespace Webshop.Data.Persistence.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ShopDbContext context): base(context) {}

        public Customer GetCustomerByWebShopId(string id)
        {
            return ShopDbContext.Customers.Where(c => c.WebshopUserId.Equals(id)).SingleOrDefault();
        }

       public ShopDbContext ShopDbContext
        {
            get { return context as ShopDbContext; }
        }

    }
}
