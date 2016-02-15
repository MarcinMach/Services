using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Services.businessLogic;

namespace Services.Controllers
{
    public class AllServicesController : Controller
    {
        
        // GET: AllServices
        public ActionResult Index()
        {
            var allservices = ServiceManager.GetList();
            return View(allservices);
        }



        public ActionResult Create()
        {
            // w view podajemy nazwy widoku -> nie jest błąd brak poadania ale czytelniejsze jest jak podasz 
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int Id, string servicename, float unitPrice, float netPrice, int VAT )
        {
            // TODO: mamy jakaś walidacje danych ? 
            var service = ServiceManager.AddNew(Id, servicename, unitPrice, netPrice, VAT);
            return View(service);
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

    }
}
