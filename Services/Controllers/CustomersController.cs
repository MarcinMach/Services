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
    public class CustomersController : Controller
    {
        

        // GET: Customers
        public ActionResult Index()
        {
            var customers = CustomerManager.Customers;
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

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

    }
}
