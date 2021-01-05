using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Webshop.Domain.Models
{
    public class Customer
    {

        public int CustomerId { get; set; }
        [Display(Name ="Achternaam")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Voornaam")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Straat + nr")]
        [Required]
        public string Address { get; set; }
        [Display(Name = "Postcode")]
        [Required]
        public string Zipcode { get; set; }

        public string WebshopUserId { get; set; }

        public List<Order> Orders { get; set; }
        //public WebShopUser WebshopUser { get; set; } 
        // Hmm, om dit toe te voegen reference nodig naar mijn Data
        // zo opvragen door toe te voegen aan order? Valt nog af te wachten
        //

        //https://stackoverflow.com/questions/63956730/user-entity-in-clean-architecture

    }
}
