using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Webshop.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name="Productnaam")]
        public string Name { get; set; }
        
        [Display(Name = "Prijs")]
        public decimal? Price { get; set; }
        [Display(Name = "Korte omschrijving")]
        public string DescriptionShort { get; set; }
        [Display(Name = "Grote omschrijving")]
        public string DescriptionLong { get; set; }
        [Display(Name = "Link naar afbeelding")]
        public string ImageUrl { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
