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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var selected =  CustomerManager.GetById(id);
            if(customer == null)   
            {
             
                 return HttpNotFound();          
            }
            return View(selected);
        }

 
        public ActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int Id, string name, string surname, string companyName, string street, string city, string code, int phoneNumber, string NIP)
        {
            
           var customer = CustomerManager.AddNew(Id,name,surname,companyName,street,city,code,phoneNumber,NIP);
            return View(customer);
        }

        // GET: Customers/Details/5
        public ActionResult Edit(int id)
        {
            var customer = CustomerManager.Customers;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var selected = CustomerManager.GetById(id);
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

        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            var customer = CustomerManager.Customers;
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

        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            var selected = CustomerManager.delete(Id);

            if (selected == null)
            {
                return HttpNotFound();
            }
            return View("Index");
        }

    }
}
