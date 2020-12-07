using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.ProductViewModels;

namespace ViewModels.FluentValidationConfig
{
   public class ProductFormViewModelValidator: AbstractValidator<ProductFormViewModel>
    {
        public ProductFormViewModelValidator()
        {
            RuleFor(x => x.Product.DescriptionLong).NotEmpty().WithMessage("Helaba daar");
          
        }

    }
}
