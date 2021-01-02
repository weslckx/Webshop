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
                    Order = new Order
                    {
                        OrderLines = new List<OrderDetail>()
                    }

                };


                if (User.Identity.IsAuthenticated)
                {

                    var userId = _userManager.GetUserId(User);
                    Customer customer = _unitOfWork.Customers.GetCustomerByWebShopId(userId);

                    if (customer != null)
                    {
                        orderViewModel.customer = customer;
                        orderViewModel.Email = _userManager.GetUserName(User);

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

                    orderViewModel.Order.OrderLines.Add(orderDetail);
                }

                return View(orderViewModel);
            }


            return RedirectToAction("Index", "Cart");

           

            
        }
    }
}
