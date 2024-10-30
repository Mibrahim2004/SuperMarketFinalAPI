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
            
        }
    }
}
