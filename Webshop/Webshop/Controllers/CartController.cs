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
using Newtonsoft.Json;
using Webshop.HelperClasses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Webshop.Controllers
{
    public class CartController : Controller
    {
        string cookieName = "MyCart";
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;

        public CartController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public IActionResult Index()
        {

            return View("Index",GetCart());
        }

        public IActionResult PendingCheckOut()
        {
           // TempDataExtensions.Put(TempData,"Cart", GetCart());

            TempData.Put("Cart", GetCart());
            //https://stackoverflow.com/questions/56528508/asp-net-core-tempdata-and-redirecttoaction-not-working

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("CheckOut", "Order");
            }

            return View("LoginOrContinue");
        }

        [Authorize]
        public IActionResult PendingOrderLogin()
        {
            return RedirectToAction("CheckOut", "Order");
        }

        


        public IActionResult AddToCart(int id, int quantity=1)
        {
            var cartItem = new CartItem
            {
                ProductId = id,
                Quantity = quantity
            };

            AddToCart(cartItem);

            return RedirectToAction("Index", "Cart");
        }

        public IActionResult RemoveFromCart(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }

            RemoveFromCart((int)id);


            return RedirectToAction("Index", "Cart");
        }


        //private methods

        private CartViewModel GetCart()
        {
            var cartContent = Request.Cookies[cookieName];
            string[] cartItems = null;

            CartViewModel viewModel = new CartViewModel
            {
                cartItems = new List<CartItemViewModel>()
            };

            if (!string.IsNullOrEmpty(cartContent)) // damn ""
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

        private void RemoveFromCart(int id)
        {
            var cart = GetCart();

            CartItemViewModel obj = cart.cartItems.FirstOrDefault(i => i.Product.Id == id);

            if (obj!=null)
            {
                cart.cartItems.Remove(obj); //if cart.cartitems=0, mss lege cookie implementeren?
                Response.Cookies.Append(cookieName, BuildCart(cart));
            }
        }

        private void AddToCart(CartItem cartItem)
        {
            var cartCookie = Request.Cookies[cookieName];
            string newCart = null;
            string cartitems = string.Join(';', cartItem);

            if (string.IsNullOrEmpty(cartCookie))
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
