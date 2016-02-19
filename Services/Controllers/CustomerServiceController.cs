using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.businessLogic;
using Services.Models;

namespace Services.Controllers
{
    public class CustomerServiceController : Controller
    {
        public ActionResult Index()
        {
            return View();            
        }
        
        public ActionResult Commit(int id)
        {
            var selected = CustomerManager.GetById(id);
            return View(selected);           
        }

        public ActionResult Commit()
        {
            // var selected = CustomerManager.GetById(id);
            return View();//selected);
        }
        [HttpPost]
        public JsonResult Getlist(int id)
        {
            var customerservice = new CustomerServiceModel();
            customerservice.customers = new SelectList(CustomerManager.Customers, "Id", "Name");
            return Json(customerservice, JsonRequestBehavior.AllowGet);
        }
        
    }
}