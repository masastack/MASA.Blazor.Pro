namespace Masa.Blazor.Pro;

public abstract class ProCompontentBase : ComponentBase
{
    private I18n? _languageProvider;

    [CascadingParameter]
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

    public string T(string key)
    {
        return LanguageProvider.T(key);
    }
}

