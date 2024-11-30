using FluentValidation;
using SuperMarket.Application.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.Validations.CategoryValidators
{
    public class UpdateCategoryValidator : AbstractValidator<CategoryUpdateDTO>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Name)
                   .NotEmpty()
                   .WithMessage("The Category Name cannot be empty.")
                   .Length(0, 100)
                   .WithMessage("The Category Name cannot be more than 100 characters.");
        }
    }
}