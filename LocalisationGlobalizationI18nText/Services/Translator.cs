using LocalisationGlobalizationI18nText.I18nText;
using Microsoft.AspNetCore.Components;

namespace LocalisationGlobalizationI18nText.Services;

public class Translator : ComponentBase
{
    private readonly Toolbelt.Blazor.I18nText.I18nText _i18NText;

    private FormValidationText _formValidationText = new();

    public Translator(Toolbelt.Blazor.I18nText.I18nText i18nText)
    {
        _i18NText = i18nText;
    }

    public FormValidationText GetValidationText()
    {
        return _i18NText.GetTextTableAsync<FormValidationText>(this).Result;
    }
}