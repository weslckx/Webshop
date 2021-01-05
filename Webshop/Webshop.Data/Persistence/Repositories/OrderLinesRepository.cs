using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Data.Repositories;
using Webshop.Domain.Models;

namespace Webshop.Data.Persistence.Repositories
{
    public class OrderLinesRepository : Repository<OrderDetail>, IOrderLinesRepository
    {
        public OrderLinesRepository(ShopDbContext context): base(context) { }
    }
}
