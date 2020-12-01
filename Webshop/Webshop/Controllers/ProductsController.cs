using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModels.ProductViewModels;
using Webshop.Data.Repositories;
using Webshop.Domain.Models;

namespace Webshop.Controllers
{
    public class ProductsController : Controller
    {
        //DI
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public ActionResult Index()
        {
            var products =_unitOfWork.Products.GetAll();
            return View(products);
        }


        public ActionResult NewProduct()
        {
            var viewModel = new ProductFormViewModel
            {
                Product = new Product() // niet vergeten te initialiseren!!!
            };

            return View("ProductForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ProductFormViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.Product.Id == 0)
                {
                    _unitOfWork.Products.Add(viewModel.Product);
                }
                else
                {
                    // Perhaps DTO and automapper, need to read!
                    var productInDb = _unitOfWork.Products.Get(viewModel.Product.Id);

                    productInDb.Name = viewModel.Product.Name;
                    productInDb.DescriptionShort = viewModel.Product.DescriptionShort;
                    productInDb.DescriptionLong = viewModel.Product.DescriptionLong;
                    productInDb.Price = viewModel.Product.Price;
                    productInDb.ImageUrl = viewModel.Product.ImageUrl;
                }

                _unitOfWork.Complete();
            }


            return RedirectToAction("Index", "Products");
        }
    }
}
