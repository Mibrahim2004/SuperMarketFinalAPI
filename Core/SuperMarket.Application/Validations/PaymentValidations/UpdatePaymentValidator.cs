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
            
        }
    }
}
