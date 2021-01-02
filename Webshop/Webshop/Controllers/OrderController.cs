using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ViewModels;
using Webshop.Data.Repositories;
using Webshop.Domain.Models;
using Webshop.HelperClasses;

namespace Webshop.Controllers
{
    public class OrderController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(UserManager<IdentityUser> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }


        public IActionResult CheckOut()
        {
            OrderViewModel orderViewModel = new OrderViewModel
            {
                customer = new Customer()
            };


            if (User.Identity.IsAuthenticated)
            {

                var userId = _userManager.GetUserId(User);
                Customer customer = _unitOfWork.Customers.GetCustomerByWebShopId(userId);

                if (customer!= null)
                {
                    orderViewModel.customer = customer;
                    orderViewModel.Email = _userManager.GetUserName(User);

                }


            }

           
            //CartViewModel cartViewModel = TempData.Get<CartViewModel>("Cart");

            //if (cartViewModel != null)
            //{

            //    OrderViewModel orderViewModel = new OrderViewModel
            //    {
            //        //Cart = cartViewModel,
            //        Order = new Order
            //        {
            //            OrderLines = new List<OrderDetail>()
            //        }
            //    };

            //    foreach (var item in cartViewModel.cartItems)
            //    {
            //        OrderDetail orderDetail = new OrderDetail
            //        {
            //            ProductId = item.Product.Id,
            //            Subtotal = item.Quantity * (decimal)item.Product.Price

            //        };

            //        orderViewModel.Order.OrderLines.Add(orderDetail);
            //    }


            //    if (User.Identity.IsAuthenticated)
            //    {
            //        var webshopUserId = _userManager.GetUserId(User);
            //        Customer customer = _unitOfWork.Customers.GetCustomerByWebShopId(webshopUserId);

            //        if (customer != null)
            //        {
            //            orderViewModel.IsAuthenticated = true;

            //            orderViewModel.Order.Address = customer.Address;
            //            orderViewModel.Order.FirstName = customer.FirstName;
            //            orderViewModel.Order.LastName = customer.LastName;
            //            orderViewModel.Order.ZipCode = customer.Zipcode;
            //        }
            //        else return NotFound();

            //    }
            //    else orderViewModel.IsAuthenticated = false;



            //    return View(orderViewModel);
            //}
            //else return NotFound();

            return View(orderViewModel);
        }
    }
}
