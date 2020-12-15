using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Areas.Identity.Data
{
    public class WebshopUser: IdentityUser
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }

    }
}
