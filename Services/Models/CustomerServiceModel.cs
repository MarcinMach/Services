using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Services.Models
{
    public class CustomerServiceModel
    {
        public IEnumerable<SelectListItem> customers { get; set; }
        public IEnumerable<SelectListItem> service { get; set; }


    }
}