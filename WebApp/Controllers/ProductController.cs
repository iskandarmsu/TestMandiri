using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.ViewModel;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            ProductClient PC = new ProductClient();
            ViewBag.listProducts = PC.FindAll();
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            ProductClient PC = new ProductClient();
            ViewBag.listProducts = PC.FindAll();
            //return View();
            return View("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                ProductClient PC = new ProductClient();
                PC.Create(cvm.product);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            ProductClient PC = new ProductClient();
            PC.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ProductClient PC = new ProductClient();
            OrderViewModel CVM = new OrderViewModel();
            CVM.product = PC.find(id);
            return View("Edit", CVM);
        }
        [HttpPost]
        public ActionResult Edit(OrderViewModel CVM)
        {
            ProductClient PC = new ProductClient();
            PC.Edit(CVM.product);
            return RedirectToAction("Index");
        }
    }
}