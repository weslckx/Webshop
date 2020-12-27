﻿using System;
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
        string cookieName = "MyCart";
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

        public IActionResult AddToCart(int id, int quantity=1)
        {
            var cartCookie = Request.Cookies[cookieName];
            var cartItem = new List<CartItem>();

            cartItem.Add(new CartItem
            {
                ProductId = id,
                Quantity = quantity
            });

            string cartItems = string.Join(";", cartItem);

            if (cartCookie==null)
            {
                Response.Cookies.Append(cookieName, cartItems);
            }
            else
            {
                var existingCart = Request.Cookies[cookieName];
                var newCart = existingCart + '|' + cartItems;
                Response.Cookies.Append(cookieName, newCart);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ViewMyCart()
        {

            return View("Index",GetCart());
        }


        public IActionResult DeleteFromCart(int id)
        {

            return View();
        }



        private CartViewModel GetCart()
        {
            var cartContent = Request.Cookies[cookieName];
            string[] cartItems = cartContent.Split('|'); // check if null!

            CartViewModel viewModel = new CartViewModel
            {
                cartItems = new List<CartItemViewModel>()
            };

            foreach (var item in cartItems)
            {
                string[] cartItemDetails = item.Split(';');
                int productId = int.Parse(cartItemDetails[0]); //tryparse
                int quantity = int.Parse(cartItemDetails[1]);
                
                Product product = _unitOfWork.Products.Get(productId);
                

                CartItemViewModel cartItemViewModel = new CartItemViewModel
                {
                    Product=product,
                    Quantity = quantity
                };

                viewModel.cartItems.Add(cartItemViewModel);
            }


            return viewModel;
        }

       
    }
}
