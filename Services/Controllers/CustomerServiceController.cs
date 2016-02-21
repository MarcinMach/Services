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
          
            var customerservice = new CustomerServiceModel();
            customerservice.Customers = new SelectList(CustomerManager.Customers, "Id", "Name");
            return View("Index", customerservice);           

        }
        
        [HttpPost]
        public ActionResult GenerateInvoice(CustomerServiceModel model)
        {
            //w modelu mam id kontrahenta i usługę mogę utworzyć fakturę 
            // faktura ma być wyświetlona w html na początku ! 
       
            return View();
        }

        public JsonResult GetCustomerById(int customerId)
        {
            var customer = CustomerManager.GetById(customerId);
            return Json(customer, JsonRequestBehavior.AllowGet);
        }
        
    }
}