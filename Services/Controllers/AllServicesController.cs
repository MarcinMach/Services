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

        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.UnitSortParm = sortOrder == "UnitPrice" ? "UnitPrice_desc" : "UnitPrice";
            ViewBag.NetSortParm = sortOrder == "NetPrice" ? "NetPrice_desc" : "NetPrice";
            ViewBag.VatSortParm = sortOrder == "Vat" ? "Vat_desc" : "Vat";
            ViewBag.VatAmountSortParm = sortOrder == "VatAmount" ? "VatAmount_desc" : "VatAmount";
            ViewBag.PretaxSortParm = sortOrder == "PretaxPrice" ? "PretaxPrice_desc" : "PretaxPrice";

            var service = ServiceManager.GetList();
            if (!String.IsNullOrEmpty(searchString))
            {
                service = service.Where(s => s.ServiceName.Contains(searchString)).ToList();
            }
            switch (sortOrder)
            {
                case "name_desc":
                    service = service.OrderBy(s => s.ServiceName).ToList();
                    break;
                case "UnitPrice":
                    service = service.OrderBy(s => s.UnitPrice).ToList();
                    break;
                case "UnitPrice_desc":
                    service = service.OrderByDescending(s => s.UnitPrice).ToList();
                    break;
                case "NetPrice":
                    service = service.OrderBy(s => s.NetPrice).ToList();
                    break;
                case "NetPrice_desc":
                    service = service.OrderByDescending(s => s.NetPrice).ToList();
                    break;
                case "Vat":
                    service = service.OrderBy(s => s.Vat).ToList();
                    break;
                case "Vat_desc":
                    service = service.OrderByDescending(s => s.Vat).ToList();
                    break;
                case "VatAmount":
                    service = service.OrderBy(s => s.VatAmount).ToList();
                    break;
                case "VatAmount_desc":
                    service = service.OrderByDescending(s => s.VatAmount).ToList();
                    break;
                case "PretaxPrice":
                    service = service.OrderBy(s => s.PretaxPrice).ToList();
                    break;
                case "PretaxPrice_desc":
                    service = service.OrderByDescending(s => s.PretaxPrice).ToList();
                    break;
                default:
                    service = service.OrderByDescending(s => s.ServiceName).ToList();
                    break;

            }
            return View(service.ToList());
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
