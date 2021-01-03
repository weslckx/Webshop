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

        //Get
        public IActionResult CheckOut()
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            CartViewModel cartItems = TempData.Get<CartViewModel>("Cart");

            if (cartItems!=null)
            {


                orderViewModel.Cart = cartItems.cartItems; // overview cart
                orderViewModel.customer = new Customer(); // initialising
               


                if (User.Identity.IsAuthenticated) // user logged in? Get data from user, else guest need to give his data
                {

                    var userId = _userManager.GetUserId(User);
                    Customer customer = _unitOfWork.Customers.GetCustomerByWebShopId(userId);

                    if (customer != null)
                    {
                        orderViewModel.customer = customer;
                        orderViewModel.Email = User.Identity.Name;
                    }
                    else return NotFound();

                }

                return View("CheckOut",orderViewModel);
            }

            // If cart is empty
            return RedirectToAction("Index", "Cart");

           

            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckOut(OrderViewModel viewModel)
        {
            
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    FirstName = viewModel.customer.FirstName,
                    LastName = viewModel.customer.LastName,
                    Address = viewModel.customer.Address,
                    Email = viewModel.Email,
                    ZipCode = viewModel.customer.Zipcode,
                    OrderPlaced = DateTime.Now,
                    OrderLines = new List<OrderDetail>()
                    
                };

                if (viewModel.customer.CustomerId !=0)
                {
                    order.CustomerId = viewModel.customer.CustomerId; // add ID only when logged in as customer.
                }

                foreach (var item in viewModel.Cart)
                {
                    var orderDetail = new OrderDetail
                    {
                        ProductId = item.Product.Id,
                        Quantity = item.Quantity
                    };

                    order.OrderLines.Add(orderDetail);
                }

                _unitOfWork.Orders.Add(order);
                _unitOfWork.Complete();

                var orderCompleteViewModel = new OrderCompletedViewModel
                {
                    Date = order.OrderPlaced,
                    OrderId = order.Id
                };

                // Clear cart -> in the future as service
                Response.Cookies.Append("MyCart", "");

                return View("CheckOutCompleted",orderCompleteViewModel);
            }

            return View(viewModel);
        }

   
    }
}
