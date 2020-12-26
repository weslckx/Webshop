using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Webshop.Domain.Models
{
    [NotMapped]
    public class Cart
    {
        public List<CartItem> CartItems { get; set; }
    }
}
