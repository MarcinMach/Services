using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Models
{
    public class InvoiceModel
    {
        public int ServiceId { get; set; }
       
        public string ServiceName { get; set; }
       
        public float UnitPrice { get; set; }
       
        public double NetPrice { get; set; }

        public int Vat { get; set; }
        
        public double VatAmount { get; set; }

        public double PretaxPrice { get; set; }

        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string CompanyName { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public int Code { get; set; }

        public Nullable<int> PhoneNumber { get; set; }

        public int NIP { get; set; }

        public List<int> AllServices { get; set; }

        public int SellerId { get; set; }

        public string SellerName { get; set; }

        public string SellerSurname { get; set; }

        public string SellerCompanyName { get; set; }

        public string SellerStreet { get; set; }

        public string SellerCity { get; set; }

        public int SellerCode { get; set; }

        public Nullable<int> SellerPhoneNumber { get; set; }

        public int SellerNIP { get; set; }
    }
}