using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewModels.ProductViewModels;
using Webshop.Data.Repositories;
using Webshop.Domain.Models;
using Webshop.HelperClasses;

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

        public async Task<IActionResult> Index(int pageNumber=1)
        {

            var products = await _unitOfWork.Products.GetAll();
            var productList = products.ToList();

            //var products = await _unitOfWork.Products.GetAll();

            return View(await PaginatedList<Product>.CreateAsync(productList, pageNumber, 6));

            //ListProductViewModel viewModel = new ListProductViewModel
            //{
            // Products= products
            //};

            //return View(viewModel);
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
            throw new Exception();
            return View();
        }

        [Route("/Home/HandleError/{code:int}")]
        public IActionResult Error()
        {
            return View("404");
        }
    }
}
