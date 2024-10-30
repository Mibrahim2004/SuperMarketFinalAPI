using FluentValidation;
using SuperMarket.Application.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.Validations.UserValidators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDTO>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .MaximumLength(20).WithMessage("Username must be at most 18 characters.");

            RuleFor(x => x.FirstName)
               .NotEmpty().WithMessage("Firstname is required.")
               .MaximumLength(20).WithMessage("Username must be at most 18 characters.");

            RuleFor(x => x.LastName)
               .NotEmpty().WithMessage("Lastname is required.")
               .MaximumLength(20).WithMessage("Username must be at most 18 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters.");
        }
    }
}
