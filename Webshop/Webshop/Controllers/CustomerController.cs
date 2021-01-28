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

    
        public IActionResult Index(CustomerViewModel vm)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditData(CustomerViewModel vm)
        {
            if (vm == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                var webshopUserId = _userManager.GetUserId(User);
                var customerInDb = _unitOfWork.Customers.GetCustomerByWebShopId(webshopUserId);

                if (customerInDb == null)
                    return NotFound();

                customerInDb.FirstName = vm.Customer.FirstName;
                customerInDb.LastName = vm.Customer.LastName;
                customerInDb.Address = vm.Customer.Address;
                customerInDb.Zipcode = vm.Customer.Zipcode;

                _unitOfWork.Complete();

                return View();
            
            }


            return View("Index", vm);

        }
    }
}
