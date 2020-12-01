using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Domain.Models;



namespace ViewModels.ProductViewModels
{
    public class ProductFormViewModel
    {

        public Product Product { get; set; }

     
        public string FormTitle
        {
            get
            {
                return (Product.Id != 0) ? "Bewerk product" : "Voeg product toe";
            }
        }

        public string ButtonText
        {
            get
            {
                return (Product.Id != 0) ? "Pas product aan" : "Toevoegen";
            }
        }

  
    }
}
