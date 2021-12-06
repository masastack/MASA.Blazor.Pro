using BlazorComponent.Components;
using Microsoft.AspNetCore.Components;

namespace MASA.Blazor.Pro.Demo
{
    public abstract class DemoCompontentBase : ComponentBase
    {
        private I18n? _languageProvider;

        [Inject]
        public I18n LanguageProvider
        {
            get
            {
                return _languageProvider ?? throw new Exception("please Inject LanguageProvider!");
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
}
