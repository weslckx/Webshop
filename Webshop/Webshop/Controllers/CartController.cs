using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webshop.Data.Repositories;
using Webshop.Domain.Models;

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

        public IActionResult AddToCart(int productId)
        {
           

            if (Request.Cookies[cartCookie]==null)
            {
                var cart = new List<CartItem>();

                cart.Add(new CartItem
                {
                    ProductId = productId,
                    Quantity=1
                });

                Response.Cookies.Append(cartCookie, cart.ToString());
               
            }

            return View("Index");
        }

       
    }
}
