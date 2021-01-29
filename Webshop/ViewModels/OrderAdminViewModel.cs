using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Domain.Models;

namespace ViewModels
{
    public class OrderAdminViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
        public string OrderSearch { get; set; }
    }
}
