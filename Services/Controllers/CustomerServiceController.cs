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
            customerservice.Service = new SelectList(ServiceManager.Service, "Id", "ServiceName");
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
            var data = new
            {
                name = customer.Name,
                surname = customer.Surname,
                companyName = customer.CompanyName,
                city = customer.City,
                street = customer.Street,
            };


            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddService(int customerId)
        {
            var service = ServiceManager.GetById(customerId);
            var data = new
            {
                serviceName = service.ServiceName,
                unitPrice = service.UnitPrice,
                netPrice = service.NetPrice,
                vat = service.Vat,
                vatAmount = service.VatAmount,
                pretaxPrice = service.PretaxPrice,
            };


            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetServiceById(int serviceId)
        {
            var service = ServiceManager.GetById(serviceId);
            var data = new
            {
                serviceName = service.ServiceName,
                unitPrice = service.UnitPrice,
                netPrice = service.NetPrice,
                vat = service.Vat,
                vatAmount = service.VatAmount,
                pretaxPrice = service.PretaxPrice,

            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Invoice()
        {

            return View();
        }
   }
}
