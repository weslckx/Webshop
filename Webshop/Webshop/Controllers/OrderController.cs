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
            CartViewModel cartViewModel = TempData.Get<CartViewModel>("Cart");

            if (cartViewModel!=null)
            {
                OrderViewModel orderViewModel = new OrderViewModel
                {
                    customer = new Customer(),
                    OrderDetails = new List<OrderDetail>()

                };


                if (User.Identity.IsAuthenticated)
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

                foreach (var item in cartViewModel.cartItems)
                {
                    OrderDetail orderDetail = new OrderDetail
                    {
                        ProductId = item.Product.Id,
                        Product = item.Product,
                        Quantity = item.Quantity
                    };

                    orderViewModel.OrderDetails.Add(orderDetail);
                }

                return View("CheckOut",orderViewModel);
            }


            return RedirectToAction("Index", "Cart");

           

            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckOut(OrderViewModel viewModel)
        {
            var order = new Order
            {
                CustomerId = viewModel.customer.CustomerId,
                FirstName = viewModel.customer.FirstName,
                LastName = viewModel.customer.LastName,
                Address = viewModel.customer.Address,
                Email = viewModel.Email,
                ZipCode = viewModel.customer.Zipcode,
                OrderPlaced = DateTime.Now
            };

            
       

            if (ModelState.IsValid)
            {
               
            }

            return RedirectToAction("Index", "Cart");
        }

   
    }
}
