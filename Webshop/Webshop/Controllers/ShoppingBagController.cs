using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Webshop.Controllers
{
    public class ShoppingBagController : Controller
    {
        

        public IActionResult Index()
        {
            ViewData["id"] = HttpContext.Session.Id;

            return View();
        }
    }
}
