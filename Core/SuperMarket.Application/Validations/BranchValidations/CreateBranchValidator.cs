using FluentValidation;
using SuperMarket.Application.DTOs.BranchDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.Validations.BranchValidations
{
    public class CreateBranchValidator : AbstractValidator<BranchCreateDTO>
    {
        public CreateBranchValidator()
        {
            
        }
    }
}
