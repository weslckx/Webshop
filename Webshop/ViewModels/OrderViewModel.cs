using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Domain.Models;

namespace ViewModels
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public bool IsAuthenticated { get; set; }
        public Customer customer { get; set; }
        public string Email { get; set; }
    }
}
