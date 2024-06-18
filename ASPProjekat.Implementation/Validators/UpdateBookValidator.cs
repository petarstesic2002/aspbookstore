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
    public class UpdateBookValidator:AbstractValidator<UpdateBookDto>
    {
        public UpdateBookValidator(ASPContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Title)
                .MinimumLength(2);
            RuleFor(x => x.Description).MinimumLength(2);
            RuleFor(x => x.Isbn).MinimumLength(2);
            RuleFor(x => x.AuthorId).GreaterThan(0);
            RuleFor(x => x.PublicationYear).MaximumLength(4);
        }
    }
}
