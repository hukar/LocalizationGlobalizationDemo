using LocalisationGlobalizationI18nText.Model;
using FluentValidation;
using LocalisationGlobalizationI18nText.Services;

namespace LocalisationGlobalizationI18nText.Validators;

public class EmployeeValidator : AbstractValidator<Employee>
{

    public EmployeeValidator(Translator translator)
    {
        
        RuleFor(e => e.Name)
            .NotEmpty()
            .Length(3, 15);
        RuleFor(e => e.Age)
            .NotEmpty()
            .InclusiveBetween(0, 120);
        RuleFor(e => e.EmployeeType)
            .NotEmpty()
            .Length(3, 15)
            .MustAsync(IsTypeExists).WithMessage((Employee e) => translator.GetValidationText().IsTypeExistsMessage);
        RuleFor(e => e.NumberOfChildren)
            .GreaterThan(0).When(e => e.HaveChildren, ApplyConditionTo.CurrentValidator)
            .Equal(0).When(e => !e.HaveChildren, ApplyConditionTo.CurrentValidator);
    }

    private async Task<bool> IsTypeExists(string typeToCheck, CancellationToken token)
    {
        List<string> typeValid = new() { "Bronze", "Silver", "Gold" };

        await Task.Delay(500, token);

        return typeValid.Contains(typeToCheck);
    }
}