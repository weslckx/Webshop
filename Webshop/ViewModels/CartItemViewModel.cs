using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Domain.Models;

namespace ViewModels
{
    public class CartItemViewModel
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public double SubTotal 
        {
            get
            {
                return (double)Product.Price * Quantity;
            } 
        }

        public string SubTotalText
        {
            get
            {
                return SubTotal.ToString("€ "+"0.00");
            }
        }

    }
}
