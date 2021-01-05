﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Webshop.Domain.Models;

namespace ViewModels
{
    public class OrderViewModel
    {
        public List<OrderDetail> OrderDetails { get; set; }
        public List<CartItemViewModel> Cart { get; set; }
        public Customer customer { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
