using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Data.Repositories;
using Webshop.Domain.Models;

namespace Webshop.Data.Persistence.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ShopDbContext context): base(context) {}
    }
}
