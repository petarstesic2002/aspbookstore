using ASPProjekat.ApplicationLayer.DTO;
using ASPProjekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.Validators
{
    public class CreateOrderValidator:AbstractValidator<CreateOrderDto>
    {
        public CreateOrderValidator(ASPContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x=>x.OrderItems).NotEmpty();
            RuleFor(x=>x.UserId).NotEmpty().GreaterThan(0);
        }
    }
}
