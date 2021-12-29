namespace MASA.Blazor.Pro;

public abstract class ProCompontentBase : ComponentBase
{
    private I18n? _languageProvider;

    [Inject]
    public I18n LanguageProvider
    {
        get
        {
            return _languageProvider ?? throw new Exception("please Inject I18n!");
        }
        set
        {
            _languageProvider = value;
        }
    }

    public abstract string Name { get; }

    public string T(string key)
    {
        return LanguageProvider.T(key) ?? key;
    }
}

