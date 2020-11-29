using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Product
{
    public class ProductFormViewModel
    {
        #region Product Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string DescriptionShort { get; set; }
        public string DescriptionLong { get; set; }
        public string ImageUrl { get; set; }
        #endregion

        #region Form Title
        public string FormTitle
        {
            get
            {
                return (Id != 0) ? "Bewerk product" : "Voeg product toe";
            }
        }

        #endregion
    }
}
