using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ViewModels;
using Webshop.Data.Repositories;
using Webshop.Domain.Models;

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
            var order = new Order();

            if (User.Identity.IsAuthenticated)
            {
                var webshopUserId = _userManager.GetUserId(User);
                Customer customer = _unitOfWork.Customers.GetCustomerByWebShopId(webshopUserId);

                if (customer != null)
                {
                    order.Address = customer.Address;
                    order.FirstName = customer.FirstName;
                    order.LastName = customer.LastName;
                    order.ZipCode = customer.Zipcode;
                }
                else return NotFound();

            }
            return View(order);
        }
    }
}
