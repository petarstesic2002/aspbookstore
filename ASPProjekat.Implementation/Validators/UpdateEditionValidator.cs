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
    public class UpdateEditionValidator:AbstractValidator<UpdateEditionDto>
    {
        public UpdateEditionValidator(ASPContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.BookId)
                .GreaterThan(0);
            RuleFor(x => x.PublisherId).GreaterThan(0);


        }
    }
}
