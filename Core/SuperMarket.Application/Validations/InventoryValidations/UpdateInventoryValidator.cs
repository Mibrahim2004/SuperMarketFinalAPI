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
            
        }
    }
}
