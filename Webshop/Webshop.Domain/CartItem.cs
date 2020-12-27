using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Webshop.Domain.Models
{
    [NotMapped]
    public class CartItem
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }

        public override string ToString()
        {
            return $"{ProductId};{Quantity}";
        }
    }
}
