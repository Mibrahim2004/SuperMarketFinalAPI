using FluentValidation;
using SuperMarket.Application.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.Validations.ProductValidators
{
    public class UpdateProductValidator : AbstractValidator<ProductUpdateDTO>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("The Category ID must be greater than 0.");

            RuleFor(x => x.Name)
                    .NotEmpty()
                    .WithMessage("The Product Name cannot be empty.")
                    .Length(0, 100)
                    .WithMessage("The Product Name cannot be more than 100 characters.");

            RuleFor(x => x.Stock)
                    .NotEmpty()
                    .GreaterThan(0).WithMessage("The stock cannot be empty and must be greater than 0. ");

            RuleFor(x => x.Price).GreaterThan(0).WithMessage("The Product Price must be greater than 0.");
        }
    }
}
