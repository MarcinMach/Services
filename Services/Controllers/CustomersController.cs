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
           public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.SurnameSortParm = sortOrder == "Surname" ? "surname_desc" : "Surname";
            ViewBag.CompanySortParm = sortOrder == "Company" ? "company_desc" : "Company";
            ViewBag.CitySortParm = sortOrder == "Ctiy" ? "city_desc" : "Ctiy";
            ViewBag.StreetSortParm = sortOrder == "Street" ? "street_desc" : "Street";

            var customer = CustomerManager.GetList();
            if (!String.IsNullOrEmpty(searchString))
            {
                customer = customer.Where(s => s.Name.Contains(searchString)).ToList();
            }
            switch (sortOrder)
            {
                case "name_desc":
                    customer = customer.OrderByDescending(s => s.Name).ToList();
                    break;
                case "Surname":
                    customer = customer.OrderBy(s => s.Surname).ToList();
                    break;
                case "surname_desc":
                    customer = customer.OrderByDescending(s => s.Surname).ToList();
                    break;
                case "Company":
                    customer = customer.OrderBy(s => s.CompanyName).ToList();
                    break;
                case "company_desc":
                    customer = customer.OrderByDescending(s => s.CompanyName).ToList();
                    break;
                case "Ctiy":
                    customer = customer.OrderBy(s => s.City).ToList();
                    break;
                case "city_desc":
                    customer = customer.OrderByDescending(s => s.City).ToList();
                    break;
                case "Street":
                    customer = customer.OrderBy(s => s.Street).ToList();
                    break;
                case "street_desc":
                    customer = customer.OrderByDescending(s => s.Street).ToList();
                    break;
                default:
                    customer = customer.OrderBy(s => s.Name).ToList();
                    break;
            }
            return View(customer.ToList());
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
