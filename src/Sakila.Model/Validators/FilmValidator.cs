using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Model.Validators;

// dotnet add package FluentValidation
public class FilmValidator : AbstractValidator<Film>
{
    public FilmValidator()
    {
        RuleFor(p=>p.Title)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50);

        RuleFor(p => p.RentalRate)
            .GreaterThan(1)
            .When(p => p.RentalDuration > 5);
    }

    
}
