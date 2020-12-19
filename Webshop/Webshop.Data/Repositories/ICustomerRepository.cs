using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Domain.Models;

namespace Webshop.Data.Repositories
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        Customer GetCustomerByWebShopId(string id);
    }
}
