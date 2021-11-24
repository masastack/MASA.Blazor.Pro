using MASA.Blazor.Pro.Global;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace MASA.Blazor.Pro.Demo
{
    public abstract class DemoCompontentBase : ComponentBase
    {
        private LanguageProvider? _languageProvider;

        [Inject]
        public LanguageProvider LanguageProvider
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

        private GlobalConfigs? _globalConfig;

        [Inject]
        public GlobalConfigs GlobalConfig
        {
            get
            {
                return _globalConfig ?? throw new Exception("please Inject GlobalConfig!");
            }
            set
            {
                _globalConfig = value;
            }
        }

        //private GloabEvent? _gloabEvent;

        //[Inject]
        //[DisallowNull]
        //public GloabEvent GloabEvent
        //{
        //    get
        //    {
        //        return _gloabEvent ?? throw new Exception("please Inject GloabEvent!");
        //    }
        //    set
        //    {
        //        _gloabEvent = value;
        //    }
        //}

        //private void InvokeStateHasChanged()
        //{
        //    InvokeAsync(() =>
        //    {
        //        StateHasChanged();
        //    });
        //}

        //protected override void OnInitialized()
        //{
        //    GloabEvent.AddEvent(InvokeStateHasChanged);
        //}

        public abstract string Name { get; }

        public string T(string key)
        {
            return LanguageProvider.LanguageMap[Name].GetValueOrDefault(key) ?? key;
        }
    }
}
