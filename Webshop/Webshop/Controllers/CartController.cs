using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webshop.Data.Repositories;
using Webshop.Domain.Models;
using System.Web;
using ViewModels;

namespace Webshop.Controllers
{
    public class CartController : Controller
    {
        string cartCookie = "MyCart";
        private readonly IUnitOfWork _unitOfWork;

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            string key = "MyCart";
            string value = "testing";

            CookieOptions cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(365)
            };

            Response.Cookies.Append(key, value,cookieOptions);



            return View();
        }

        public IActionResult AddToCart(int productId, int quantity=1)
        {

            var cartItem = new List<CartItem>();

            cartItem.Add(new CartItem
            {
                ProductId = productId,
                Quantity = quantity
            });

            string cartItems = string.Join(";", cartItem);

            if (Request.Cookies[cartCookie]==null)
            {
                Response.Cookies.Append(cartCookie, cartItems);
            }
            else
            {
                var existingCart = Request.Cookies[cartCookie];
                var newCart = existingCart + '|' + cartItems;
                Response.Cookies.Append(cartCookie, newCart);
            }

           

                

        
           

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ViewMyCart()
        {
            var cart = Request.Cookies[cartCookie];
            var cartViewModel = new CartViewModel
            {
                products = new List<Product>()
            };

            var cartItems = cart.Split('|');

            foreach (var item in cartItems)
            {
               var carItemDetails = item.Split(';');
               var product= _unitOfWork.Products.Get(int.Parse(carItemDetails[0]));
               cartViewModel.products.Add(product);

            }

            return View("Index",cartViewModel);
        }

       
    }
}
