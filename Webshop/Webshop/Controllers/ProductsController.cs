using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Product;

namespace Webshop.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewProduct()
        {
            var viewModel = new ProductFormViewModel();

            return View("ProductForm", viewModel);
        }
    }
}
