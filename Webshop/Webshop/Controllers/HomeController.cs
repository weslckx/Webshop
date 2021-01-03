using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewModels.ProductViewModels;
using Webshop.Data.Repositories;

namespace Webshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            ListProductViewModel viewModel = new ListProductViewModel
            {
                Products = _unitOfWork.Products.GetAll().ToList()
            };

            return View(viewModel);
        }

        public IActionResult Search(ListProductViewModel viewModel)
        {
            if (!string.IsNullOrWhiteSpace(viewModel.ProductSearch))
            {
                viewModel.Products = _unitOfWork.Products.Find(p => p.Name.Contains(viewModel.ProductSearch)).ToList();
                return View("Index", viewModel);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
