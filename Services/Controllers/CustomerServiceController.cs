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
        public ActionResult Index(int id)
        {
            int nevid;
            var customerservice = new CustomerServiceModel();
            customerservice.customers = new SelectList(CustomerManager.Customers, "Id", "Name");
            CustomerManager.GetById(id);
            nevid = id;

            return View(customerservice);
            
        }
        [HttpPost]
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
    }
}