using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Application.DTOs.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.Validations.CustomerValidators
{
    public  class CreateCustomerValidator : AbstractValidator<CustomerCreateDTO>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .Length(2, 50).WithMessage("First name must be between 2 and 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .Length(2, 50).WithMessage("Last name must be between 2 and 50 characters.");

            RuleFor(x => x.Email)
               .NotNull().NotEmpty().WithMessage("Email address cannot be empty.")
               .EmailAddress().WithMessage("Please enter a valid email address.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .Length(6, 100).WithMessage("Address must be between 6 and 100 characters.");
        }
    }
}