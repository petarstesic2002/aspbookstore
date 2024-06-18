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
    public class CreateEditionValidator : AbstractValidator<CreateEditionDto>
    {
        public CreateEditionValidator(ASPContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.BookId)
                .NotEmpty().GreaterThan(0);
            RuleFor(x=>x.Price)
                .NotEmpty().GreaterThan(0);
            RuleFor(x => x.AvailableStores)
                .NotEmpty();
            RuleFor(x => x.PublisherId)
                .NotEmpty().GreaterThan(0);


        }
    }
}
