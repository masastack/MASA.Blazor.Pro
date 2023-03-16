namespace Masa.Blazor.Pro;

public abstract class ProComponentBase : ComponentBase
{
    private string? _culture;

    [Inject]
    protected I18n? LanguageProvider { get; set; }
    
    [CascadingParameter(Name = "CultureName")]
    protected string? Culture
    {
        get => _culture;
        set
        {
            if (_culture != null && !Equals(_culture, value))
            {
                OnLanguageChanged();
            }

            _culture = value;
        }
    }

    protected string? T(string? key, params object[] args)
    {
        return LanguageProvider?.T(key, args: args);
    }

    protected virtual void OnLanguageChanged()
    {
    }
}
