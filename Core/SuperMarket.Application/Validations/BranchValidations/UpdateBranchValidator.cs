using FluentValidation;
using SuperMarket.Application.DTOs.BranchDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.Validations.BranchValidations
{
    public class UpdateBranchValidator : AbstractValidator<BranchUpdateDTO>
    {
        public UpdateBranchValidator()
        {
            RuleFor(x => x.Name)
                    .NotEmpty()
                    .WithMessage("The Branch Name cannot be empty.")
                    .Length(0, 100)
                    .WithMessage("The Branch Name cannot be more than 100 characters.");

            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("The address can't be empty.");

            RuleFor(x => x.City)
                .NotEmpty()
                .Length(0, 50)
                .WithMessage("The city can't be empty.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("The phone number can't be empty.");
        }
    }
}