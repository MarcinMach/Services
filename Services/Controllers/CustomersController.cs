using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Services.businessLogic;
using System.Data.Entity.Infrastructure;

namespace Services.Controllers
{
    public class CustomersController : Controller
    {
        //TODO: POPRAW STRONY ABY KORZYSTAŁY Z GŁÓWNEGO LAYOUT ! TO JEST BARDZO WAŻNE ! PO TO JEST     @RenderBody() W LAYOUT ABY NIE WCZYTYWA CAŁEJ STRONY TYLKO GENEROWA ZAWARTOŚC

        // GET: Customers
        public ActionResult Index()
        {
            var customers = CustomerManager.GetList();
            return View(customers);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            var customer = CustomerManager.Customers;
            //TODO: 1 == null ??? 
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var selected =  CustomerManager.GetById(id);
            //TODO: Po co jest to sprawdzane ? 
            if(customer == null)   
            {
             
                 return HttpNotFound();          
            }
            return View(selected);
        }

 
        public ActionResult Create()
        {
            // w view podajemy nazwy widoku -> nie jest błąd brak poadania ale czytelniejsze jest jak podasz 
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int Id, string name, string surname, string companyName, string street, string city, string code, int phoneNumber, string NIP)
        {
            // TODO: mamy jakaś walidacje danych ? 
           var customer = CustomerManager.AddNew(Id,name,surname,companyName,street,city,code,phoneNumber,NIP);
            return View(customer);
        }

        // GET: Customers/Details/5
        public ActionResult Edit(int id)
        {
            var customer = CustomerManager.Customers;
            //TODO: int  może być nulle ? 
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var selected = CustomerManager.GetById(id);

            //TODO: Po co jest to sprawdzane ? 
            if (customer == null)
            {

                return HttpNotFound();
            }
            return View(selected);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int Id, string name, string surname, string companyName, string street, string city, string code, int phoneNumber, string NIP)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = CustomerManager.Edit(Id, name, surname, companyName, street, city, code, phoneNumber, NIP);
            return RedirectToAction("Index");

        }
        // TODO:
        // może być nulle ale domyślnie niech będzie false ?? czyli zawsze jest false ? czy może byc nullem ? 
        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            var customer = CustomerManager.Customers;
           //TODO: int  może być nulle ? 
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            var selected = CustomerManager.GetById(id);
            if (customer == null)
            {

                return HttpNotFound();
            }
            return View(selected);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id)
        { //TODO: int  może być nulle ? 
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           // TODO: o co chodzi z tym zwracaniem null 
            var selected = CustomerManager.delete(Id);

            if (selected == null)
            {
                // zawsze tutaj lądujesz 
                return HttpNotFound();
            }
            return View("Index");
        }

    }
}
