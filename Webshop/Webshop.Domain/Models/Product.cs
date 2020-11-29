using System;
using System.Collections.Generic;
using System.Text;

namespace Webshop.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string DescriptionShort { get; set; }
        public string DescriptionLong { get; set; }
        public string ImageUrl { get; set; }
    }
}
