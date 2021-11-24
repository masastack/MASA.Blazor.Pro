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

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }

        protected override bool ShouldRender()
        {
            return base.ShouldRender();
        }

        public abstract string Name { get; }

        public string T(string key)
        {
            return LanguageProvider.LanguageMap[Name].GetValueOrDefault(key) ?? key;
        }
    }
}
