using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Data.Repositories;
using Webshop.Domain.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Webshop.Data.Persistence.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ShopDbContext context):base(context) {}

        public IEnumerable<Order> GetOrdersWithProducts(int id)
        {
            // Add Linq!
            // add EntityFrameWorkCore
            var query = shopDbContext.Orders
                .Where(c => c.CustomerId == id)
                .Include(order => order.OrderLines)
                .ThenInclude(order => order.Product);

            return query;
            
        }

        public Order GetOrderWithProducts(int id)
        {
            var order = shopDbContext.Orders
                .Where(c => c.Id == id)
                .Include(order=>order.OrderLines)
                .ThenInclude(order=>order.Product)
                .SingleOrDefault();

            return order;
        }

        public ShopDbContext shopDbContext
        {
            get { return context as ShopDbContext; }
        }
    }
}
