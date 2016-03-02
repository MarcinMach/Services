using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Services.Models
{
    public abstract class PersonModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname required")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "CompanyName required")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Street required")]
        public string Street { get; set; }

        [Required(ErrorMessage = "City required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Code required")]
        public int Code { get; set; }

        public Nullable<int> PhoneNumber { get; set; }

        [Required(ErrorMessage = "NIP required")]
        public int NIP { get; set; }

        

    }
}