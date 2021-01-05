using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Domain.Models;

namespace Webshop.Data.Repositories
{
   public interface IOrderRepository: IRepository<Order>
    {
        IEnumerable<Order> GetOrdersWithProducts(int id);
        Order GetOrderWithProducts(int id);
    }
}
