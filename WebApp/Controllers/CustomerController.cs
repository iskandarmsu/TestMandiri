using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.ViewModel;

namespace WebApp.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            CustomerClient CC = new CustomerClient();
            ViewBag.listCustomers = CC.FindAll();
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            CustomerClient CC = new CustomerClient();
            ViewBag.listCustomers = CC.FindAll();
            //return View();
            return View("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                CustomerClient CC = new CustomerClient();
                CC.Create(cvm.customer);
            }
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            CustomerClient CC = new CustomerClient();
            CC.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            CustomerClient CC = new CustomerClient();
            OrderViewModel CVM = new OrderViewModel();
            CVM.customer = CC.find(id);
            return View("Edit", CVM);
        }
        [HttpPost]
        public ActionResult Edit(OrderViewModel CVM)
        {
            CustomerClient CC = new CustomerClient();
            CC.Edit(CVM.customer);
            return RedirectToAction("Index");
        }
    }
}