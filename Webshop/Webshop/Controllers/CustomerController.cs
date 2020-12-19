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
    public class CustomerController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(UserManager<IdentityUser> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var webshopUserId=_userManager.GetUserId(User);
            Customer customer = _unitOfWork.Customers.GetCustomerByWebShopId(webshopUserId);

            if (customer!=null)
            {
                var viewModel = new CustomerViewModel
                {
                    Customer = customer
                };

                return View(viewModel);

            }

            return NotFound();
        }
    }
}
