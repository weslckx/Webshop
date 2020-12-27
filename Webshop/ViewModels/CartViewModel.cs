using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Domain.Models;

namespace ViewModels
{
    public class CartViewModel
    {
        public List<CartItemViewModel> cartItems { get; set; }
        public virtual string Total
        {
            get
            {
                double sum = 0;
                foreach (var product in cartItems)
                {
                    sum += product.SubTotal;
                }

                return sum.ToString("€ "+"0.00");
            }
        }
    }
}
