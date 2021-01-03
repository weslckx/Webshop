using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Domain.Models;

namespace ViewModels.ProductViewModels
{
    public class ListProductViewModel
    {
        public string ProductSearch { get; set; }
        public List<Product> Products { get; set; }
    }
}
