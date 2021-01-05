﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Webshop.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderPlaced { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        //public decimal OrderTotal { get; set; }
        public List<OrderDetail> OrderLines { get; set; }
        public int? CustomerId { get; set; } // nullable?
       
        [NotMapped]
        public string IsCustomer 
        { 
            get {

                return CustomerId!=null? "Geregistreerd": "Niet-geregistreerd";
            } 
        }

    }
}
