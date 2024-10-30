using FluentValidation;
using SuperMarket.Application.DTOs.PaymentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.Validations.PaymentValidators
{
    public class UpdatePaymentValidator : AbstractValidator<PaymentUpdateDTO>
    {
        public UpdatePaymentValidator()
        {
            RuleFor(x => x.OrderId)
           .GreaterThan(0).WithMessage("Order ID must be greater than 0.");

            RuleFor(x => x.PaymentDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Payment date cannot be in the future.");

            RuleFor(x => x.PaymentMethod)
                .NotEmpty().WithMessage("Payment method is required.")
                .Length(2, 40).WithMessage("Payment method must be between 2 and 40 characters.");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Payment amount must be greater than 0.");

        }
    }
}
