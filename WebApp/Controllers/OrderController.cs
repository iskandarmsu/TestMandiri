using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.ViewModel;

namespace WebApp.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult Index()
        {
            OrderClient CC = new OrderClient();
            ViewBag.listOrders = CC.findAll();
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            CustomerClient CX = new CustomerClient();
            ViewBag.listCustomers = CX.FindAll();
            ProductClient PC = new ProductClient();
            ViewBag.listProducts = PC.FindAll();
            //return View();
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(OrderViewModel cvm)
        {
            OrderClient CC = new OrderClient();
            CC.Create(cvm.order);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            OrderClient CC = new OrderClient();
            CC.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            CustomerClient CX = new CustomerClient();
            ViewBag.listCustomers = CX.FindAll();
            ProductClient PC = new ProductClient();
            ViewBag.listProducts = PC.FindAll();

            OrderClient CC = new OrderClient();
            OrderViewModel CVM = new OrderViewModel();
            CVM.order = CC.find(id);
            return View("Edit", CVM);
        }
        [HttpPost]
        public ActionResult Edit(OrderViewModel CVM)
        {
            OrderClient CC = new OrderClient();
            CC.Edit(CVM.order);
            return RedirectToAction("Index");
        }
    }
}