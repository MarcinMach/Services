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

 
        public ActionResult GenerateInvoice(CustomerServiceModel model)
        {
            var invoice = new InvoiceModel();
            var service = ServiceManager.GetById(model.SelectedService);
            var customer = CustomerManager.GetById(model.SelectedCustomer);
            var seller = SellerManager.GetById(1);
            var services = ServiceManager.GetServiceByIds(model.SelectedServices);           
                     
            invoice.Name = customer.Name;
            invoice.Surname = customer.Surname;
            invoice.City = customer.City;
            invoice.CompanyName = customer.CompanyName;
            invoice.Code = customer.Code;
            invoice.NIP = customer.NIP;
            invoice.CompanyName = customer.CompanyName;
            invoice.Street = customer.Street;
            invoice.PhoneNumber = customer.PhoneNumber;
            invoice.ServiceName = service.ServiceName;
            invoice.Vat = service.Vat;
            invoice.NetPrice = service.NetPrice;
            invoice.VatAmount = service.VatAmount;
            invoice.PretaxPrice = service.PretaxPrice;
            invoice.SellerName = seller.Name;
            invoice.SellerSurname = seller.Surname;
            invoice.SellerCity = seller.City;
            invoice.SellerCompanyName = customer.CompanyName;
            invoice.SellerCode = seller.Code;
            invoice.SellerNIP = seller.NIP;
            invoice.SellerStreet = seller.Street;
            invoice.SellerPhoneNumber = seller.PhoneNumber;
            invoice.SellerCompanyName = seller.CompanyName;
            invoice.AllServices = services.ToList();
             
            return View("Invoice", invoice);
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
