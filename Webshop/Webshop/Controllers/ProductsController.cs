using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Product;
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
            var viewModel = new ProductFormViewModel();

            return View("ProductForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Product product)
        {
            if (!ModelState.IsValid)
            {
               // Nog implementeren
            }

            if (product.Id==0)
            {
                _unitOfWork.Products.Add(product);
            }
            else
            {
                var productInDb = _unitOfWork.Products.Get(product.Id);

                productInDb.Name = product.Name;
                productInDb.DescriptionShort = product.DescriptionShort;
                productInDb.DescriptionLong = product.DescriptionLong;
                productInDb.Price = product.Price;
                productInDb.ImageUrl = product.ImageUrl;
            }

            _unitOfWork.Complete();


            return RedirectToAction("Index", "Products");
        }
    }
}
