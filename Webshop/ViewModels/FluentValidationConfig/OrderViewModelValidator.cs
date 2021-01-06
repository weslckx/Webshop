using FluentValidation;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace ViewModels.FluentValidationConfig
{
    public class OrderViewModelValidator: AbstractValidator<OrderViewModel>
    {
        public OrderViewModelValidator()
        {
            RuleFor(x => x.customer.FirstName).MinimumLength(2).WithMessage("Gelieve minstens twee karakters in te vullen.");
            RuleFor(x => x.customer.LastName).MinimumLength(2).WithMessage("Gelieve minstens twee karakters in te vullen.");
            RuleFor(x => x.customer.Zipcode).Must(IsValidPostcode).WithMessage("Gelieve geldige postcode in te vullen.");
            RuleFor(x => x.customer.Address).MinimumLength(6).WithMessage("Gelieve minstens zes karakters in te vullen.");
            RuleFor(x => x.Email).Must(IsValidEmail).WithMessage("Gelieve een geldig e-mailadres in te vullen.");

        }


        private bool IsValidPostcode(string postcode)
        {

            if (int.TryParse(postcode,out int code))
            {
                if (code >= 1000 && code <= 9999)
                    return true;
            }

            return false;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {

                return false;
            }
        }
    }
}
