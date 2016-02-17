using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Services.Models
{
    public class ServicesModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name required")]
        public string ServiceName { get; set; }

        [Required(ErrorMessage = "UnitePrice required")]
        public float UnitPrice { get; set; }

        [Required(ErrorMessage = "NetPrice required")]
        public float NetPrice { get; set; }

        [Required(ErrorMessage = "Vat required")]
        public int Vat { get; set; }
    }
}