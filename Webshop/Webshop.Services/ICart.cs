using System;
using System.Collections.Generic;
using System.Text;

namespace Webshop.Services
{
    interface ICart
    {
        void AddProductToCart(int productId);
    }
}
