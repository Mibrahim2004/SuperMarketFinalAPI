using FluentValidation;
using SuperMarket.Application.DTOs.OrderDetailsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.Validations.OrderDetailsValidations
{
    public class UpdateOrderDetailsValidator : AbstractValidator<OrderDetailsUpdateDTO>
    {
        public UpdateOrderDetailsValidator()
        {
            RuleFor(x => x.OrderId)
          .GreaterThan(0).WithMessage("Order ID must be greater than 0.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("The quantity must be greater than 0.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("The Price must be greater than 0.");
        }
    }
}
