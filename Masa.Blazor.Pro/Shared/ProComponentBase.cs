namespace Masa.Blazor.Pro;

public abstract class ProComponentBase : ComponentBase
{
    [Inject]
    protected I18n? LanguageProvider { get; set; }
    
    [CascadingParameter(Name = "CultureName")]
    protected string? Culture { get; set; }

    protected string? T(string? key, params object[] args)
    {
        return LanguageProvider?.T(key, args: args);
    }
}
