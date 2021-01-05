using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModels;
using Webshop.Data.Repositories;

namespace Webshop.Controllers
{
    public class AdminController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ViewOrders()
        {
            var orders = await _unitOfWork.Orders.GetAll();
            OrderAdminViewModel viewModel = new OrderAdminViewModel
            {
                Orders = orders
            };


            return View(viewModel);
        }
    }
}
