using FluentValidation;
using SuperMarket.Application.DTOs.InventoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.Validations.InventoryValidations
{
    public class UpdateInventoryValidator : AbstractValidator<InventoryUpdateDTO>
    {
        public UpdateInventoryValidator()
        {
            RuleFor(x => x.ProductId)
            .GreaterThan(0).WithMessage("Product ID must be greater than 0.");

            RuleFor(x => x.BranchId)
                .GreaterThan(0).WithMessage("The Branch Id must be greater than 0.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("The quantity must be greater than 0.");
        }
    }
}