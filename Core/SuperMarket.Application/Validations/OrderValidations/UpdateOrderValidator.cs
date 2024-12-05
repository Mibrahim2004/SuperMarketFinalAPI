using FluentValidation;
using SuperMarket.Application.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.Validations.OrderValidators
{
    public class UpdateOrderValidator : AbstractValidator<OrderUpdateDTO>
    {
        public UpdateOrderValidator()
        {
            RuleFor(x => x.CustomerId)
            .GreaterThan(0).WithMessage("Customer ID must be greater than 0.");

            RuleFor(x => x.OrderDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Order date cannot be in the future.");

            RuleFor(x => x.TotalAmount)
                .GreaterThan(0).WithMessage("Total amount must be greater than 0.");
        }
    }
}
