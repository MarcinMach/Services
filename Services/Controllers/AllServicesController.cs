using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Services.businessLogic;
using Services.Models;

namespace Services.Controllers
{
    public class AllServicesController : Controller
    {
        public ActionResult Index()
        {
            var allservices = ServiceManager.GetList();
            return View(allservices);
        }

        public ActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServicesModel servicesModel)
        {
            if (ModelState.IsValid)
            {
                var Newservice = ServiceManager.AddNew(servicesModel.Id, servicesModel.ServiceName, servicesModel.UnitPrice,
                                                servicesModel.NetPrice, servicesModel.Vat);

                return View(Newservice);
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            var selected = ServiceManager.GetById(id);
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            return View(selected);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id)
        {
            var selected = ServiceManager.Delete(Id);
            return View("Applay");
        }

        public ActionResult Details(int id)
        {

            var selected = ServiceManager.GetById(id);

            return View(selected);
        }

        public ActionResult Edit(int id)
        {
            var selected = ServiceManager.GetById(id);

            return View(selected);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ServicesModel servicesModel)
        {
            if (ModelState.IsValid)
            {
                var EditService = ServiceManager.Edit(servicesModel.Id, servicesModel.ServiceName, servicesModel.UnitPrice,
                                                      servicesModel.NetPrice, servicesModel.Vat);

                return View(EditService);
            }
            else
            {
                return View();
            }
        }

    }
}
