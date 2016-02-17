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
using Services.Models;

namespace Services.Controllers
{
    public class CustomersController : Controller
    {      
        public ActionResult Index()
        {
            var customers = CustomerManager.GetList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
           
            var selected =  CustomerManager.GetById(id);
         
            return View(selected);
        }
 
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( CustomerModel customerModel)
        {
            if (ModelState.IsValid)
            {
                var NewCustomer = CustomerManager.AddNew(customerModel.Name, customerModel.Surname, customerModel.CompanyName,
                    customerModel.Street, customerModel.City, customerModel.Code, customerModel.PhoneNumber, customerModel.NIP);

                return View(NewCustomer);
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
  
            var selected = CustomerManager.GetById(id);

           
            return View(selected);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(CustomerModel customerModel)
        {
            if (ModelState.IsValid)
            {
                var NewCustomer = CustomerManager.Edit(customerModel.Id, customerModel.Name, customerModel.Surname, customerModel.CompanyName,
                 customerModel.Street, customerModel.City, customerModel.Code, customerModel.PhoneNumber, customerModel.NIP);

                return View(NewCustomer);
            }
            else
            {
                return View();
            }
        }


        public ActionResult Delete(int id, bool? saveChangesError )
        {
            var selected = CustomerManager.GetById(id);
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
            var selected = CustomerManager.Delete(Id);                 
            return View("Applay");
            
           
        }
    }
}
