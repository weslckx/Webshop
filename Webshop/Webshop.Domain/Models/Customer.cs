using System;
using System.Collections.Generic;
using System.Text;


namespace Webshop.Domain.Models
{
    public class Customer
    {

        public int CustomerId { get; set; }

        public string WebshopUserId { get; set; }
        //public WebShopUser WebshopUser { get; set; } 
        // Hmm, om dit toe te voegen reference nodig naar mijn Data
        // zo opvragen door toe te voegen aan order? Valt nog af te wachten
        //

        //https://stackoverflow.com/questions/63956730/user-entity-in-clean-architecture

    }
}
