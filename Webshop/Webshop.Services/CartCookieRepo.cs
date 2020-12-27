using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Domain.Models;

namespace Webshop.Services
{
    class CartCookieRepo : ICart
    {
        private Cart Cart { get; set; }
        private CartItem CartItem { get; set; }

        public CartCookieRepo()
        {
            this.Cart = new Cart();
            this.CartItem = new CartItem();
        }

        public void AddProductToCart(int productId, int quantity)
        {
            CartItem.ProductId = productId;
            CartItem.Quantity = productId;

        }
    }
}
