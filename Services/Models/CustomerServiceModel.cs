using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Services.Models
{
    public class CustomerServiceModel
    {
        public IEnumerable<SelectListItem> Customers { get; set; }

        public IEnumerable<SelectListItem> Service { get; set; }

        public List<int> SelectedServices { get; set; }

        public int SelectedCustomer { get; set; }

        public int SelectedService { get; set; }
    }
}