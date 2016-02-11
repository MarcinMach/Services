using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.businessLogic;

namespace Services.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var customers = CustomerManager.Customers;
            return View(customers);
        }
    
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}