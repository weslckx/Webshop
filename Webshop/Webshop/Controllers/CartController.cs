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
using System.Text;

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

            return View("Index",GetCart());
        }

        public IActionResult AddToCart(int id, int quantity=1)
        {
            var cartItem = new CartItem
            {
                ProductId = id,
                Quantity = quantity
            };

            AddToCart(cartItem);

   // to delete:
            //string cartItems = string.Join(";",cartItem);

            //if (cartCookie==null)
            //{
            //    Response.Cookies.Append(cookieName, cartItems);
            //}
            //else
            //{
            //    var existingCart = Request.Cookies[cookieName];
            //    var newCart = existingCart + '|' + cartItems;
            //    Response.Cookies.Append(cookieName, newCart);
            //}

            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeleteFromCart(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }

            RemoveFromCart((int)id, GetCart());


            

            return View();
        }



        private CartViewModel GetCart()
        {
            var cartContent = Request.Cookies[cookieName];
            string[] cartItems = null;

            CartViewModel viewModel = new CartViewModel
            {
                cartItems = new List<CartItemViewModel>()
            };

            if (cartContent!=null)
            {
                cartItems = cartContent.Split('|'); // check if null! Otherwise error


                foreach (var item in cartItems)
                {
                    string[] cartItemDetails = item.Split(';');
                    int productId = int.Parse(cartItemDetails[0]); //tryparse
                    int quantity = int.Parse(cartItemDetails[1]);

                    Product product = _unitOfWork.Products.Get(productId);


                    CartItemViewModel cartItemViewModel = new CartItemViewModel
                    {
                        Product = product,
                        Quantity = quantity
                    };

                    viewModel.cartItems.Add(cartItemViewModel);
                }


                
            }
            return viewModel;


        }

        private void RemoveFromCart(int id, CartViewModel cartViewModel)
        {
            foreach (var item in cartViewModel.cartItems)
            {
                if (item.Product.Id==id)
                {
                    cartViewModel.cartItems.Remove(item);
                }
            }

            
            


        }

        private void AddToCart(CartItem cartItem)
        {
            var cartCookie = Request.Cookies[cookieName];
            string newCart = null;
            string cartitems = string.Join(';', cartItem);

            if (cartCookie==null)
            {
                Response.Cookies.Append(cookieName, cartitems);
            }
            else
            {
                var cart = GetCart();
                CartItemViewModel cartItemViewModel = new CartItemViewModel
                {
                    Product = _unitOfWork.Products.Get(cartItem.ProductId),
                    Quantity = cartItem.Quantity
                };

                CartItemViewModel obj = cart.cartItems.FirstOrDefault(i => i.Product.Id == cartItem.ProductId);

                if (obj!=null)
                {
                    obj.Quantity++;
                    newCart = BuildCart(cart);
                }
                else
                {
                    newCart = cartCookie + '|' + cartitems;
                }

                Response.Cookies.Append(cookieName, newCart);

            }
        }

        private string BuildCart(CartViewModel viewModel)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var item in viewModel.cartItems)
            {
                builder.Append(item.Product.Id.ToString());
                builder.Append(';');
                builder.Append(item.Quantity.ToString());

                if (viewModel.cartItems.IndexOf(item)!=viewModel.cartItems.Count-1)
                {
                    builder.Append('|');
                }
               
            }

            return builder.ToString();

        }
       
    }
}
