﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModels;
using Webshop.Areas.Identity.Data;
using Webshop.Data.Repositories;

namespace Webshop.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
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

            if (orders==null)
            {
                return NotFound();
            }

            OrderAdminViewModel viewModel = new OrderAdminViewModel
            {
                Orders = orders
            };


            return View(viewModel);
        }

        public IActionResult ViewOrderDetail(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }

            var order = _unitOfWork.Orders.GetOrderWithProducts((int)id);

            if (order == null)
                return NotFound();

            return View(order);
        }


        public IActionResult Delete(int? id)
        {

            if (id==null)
            {
                return NotFound();
            }

            var order=_unitOfWork.Orders.Get((int)id);

            if (order == null)
                return NotFound();


            return View(order);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var order = _unitOfWork.Orders.GetOrderWithProducts(id);
            var orderlines = _unitOfWork.OrderLines.Find(x => x.OrderId == id);

            if (order == null || orderlines == null)
                return NotFound();
          


            foreach (var orderline in orderlines)
            {
                _unitOfWork.OrderLines.Remove(orderline);
            }

            _unitOfWork.Orders.Remove(order);
          
            _unitOfWork.Complete();

            return RedirectToAction("ViewOrders");
            
        }


      
    }
}
