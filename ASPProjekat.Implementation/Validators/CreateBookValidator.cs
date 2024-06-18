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
    public class CreateBookValidator:AbstractValidator<CreateBookDto>
    {
        public CreateBookValidator(ASPContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Title)
                .NotEmpty().MinimumLength(2);
            RuleFor(x => x.Description).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Isbn).NotEmpty().MinimumLength(2);
            RuleFor(x => x.AuthorId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.PublicationYear).NotEmpty().MaximumLength(4);
            RuleFor(x => x.GenreIds).NotEmpty();

        }
    }
}
