using Bookstore.Shared.Models.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.ApplicationCore.Validations
{
    public class RatingRequestValidator : AbstractValidator<RatingRequest>
    {
        public RatingRequestValidator()
        {
            RuleFor(r => r.Score).InclusiveBetween(1, 5)
                .WithMessage("Il punteggio deve essere compreso tra 1 e 5");

            RuleFor(r => r.DateComment.Date).LessThanOrEqualTo(DateTime.Now.Date)
                .WithMessage("Non puoi inserire una data futura");
        }
    }
}
