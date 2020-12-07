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
            RuleFor(x => x.Product.Name).NotEmpty().WithMessage(GetStandardErrorMessage("productnaam"));

            RuleFor(x => x.Product.Price).NotEmpty().WithMessage(GetStandardErrorMessage("prijs"));
            RuleFor(x => x.Product.Price).InclusiveBetween(1, 99999);

            RuleFor(x => x.Product.DescriptionShort).NotEmpty().WithMessage(GetStandardErrorMessage("korte omschrijving"));

            RuleFor(x => x.Product.ImageUrl).NotEmpty().WithMessage(GetStandardErrorMessage("link naar afbeelding"));
            //https://stackoverflow.com/questions/3809401/what-is-a-good-regular-expression-to-match-a-url
            RuleFor(x => x.Product.ImageUrl).Matches(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)").WithMessage("Geen geldige link ingevoerd");

            RuleFor(x => x.Product.DescriptionLong).NotEmpty().WithMessage(GetStandardErrorMessage("grote omschrijving"));
            RuleFor(x => x.Product.DescriptionLong).MinimumLength(150).WithMessage("Grote omschrijving moet minstens {MinLength} tekens bevatten");

        }

    public string GetStandardErrorMessage(string propertyName)
        {
            return $"Gelieve {propertyName} in te vullen";
        }

    }
}
