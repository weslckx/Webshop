using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.Domain.Models;

namespace Webshop.Areas.Identity.Data
{
    [PersonalData]
    public class WebshopUser
    {
        public string Name { get; set; }

        public string FirstName { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }
  
        public string City { get; set; }

        // nog deleten
    }
}
