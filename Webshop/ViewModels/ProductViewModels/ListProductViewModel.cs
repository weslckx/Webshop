using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Domain.Models;

namespace ViewModels.ProductViewModels
{
    public class ListProductViewModel
    {
        public string ProductSearch { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
