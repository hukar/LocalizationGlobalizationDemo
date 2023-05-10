using LocalisationGlobalizationI18nText.Model;
using FluentValidation;

namespace LocalisationGlobalizationI18nText.Validators;

public class EmployeeValidator : AbstractValidator<Employee>
{
    public EmployeeValidator()
    {
        RuleFor(e => e.Name)
            .NotEmpty()
            .Length(3, 15);
        RuleFor(e => e.Age)
            .NotEmpty()
            .InclusiveBetween(0, 120);
        RuleFor(e => e.EmployeeType)
            .NotEmpty()
            .Length(3, 15);
    }
}