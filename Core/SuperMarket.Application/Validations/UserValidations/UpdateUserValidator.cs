using FluentValidation;
using SuperMarket.Application.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.Validations.UserValidators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDTO>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("User ID is required.");

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

        }
    }
}
