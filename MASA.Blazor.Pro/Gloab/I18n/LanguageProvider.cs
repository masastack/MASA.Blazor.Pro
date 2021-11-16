using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace MASA.Blazor.Pro.Gloab
{
    public partial class LanguageProvider
    {
        static LanguageProvider()
        {
            _i18nCache = new ConcurrentDictionary<string, Dictionary<string, Dictionary<string, string>>>();
        }

        private static ConcurrentDictionary<string, Dictionary<string, Dictionary<string, string>>> _i18nCache;

        private static string? _defaultLanguage;

        private static string DefaultLanguage 
        { 
            get
            {
                return _defaultLanguage ?? _i18nCache.Keys.FirstOrDefault() ?? throw new Exception("Please set language !");
            }
            set
            {
                _defaultLanguage = value;
            }
        }

        public static void AddLang(string language, Dictionary<string, Dictionary<string, string>>? langMap,bool isDefaultLanguage=false)
        {
            if (langMap is null) return;
            if (isDefaultLanguage) DefaultLanguage = language;
            _i18nCache.AddOrUpdate(language, langMap, (name, original) => langMap);
        }

        public static void AddLang(string languageSettingsFile)
        {
            var languageSettings = JsonSerializer.Deserialize<LanguageSettings>(File.ReadAllText(languageSettingsFile));
            if(languageSettings is not null)
            {
                DefaultLanguage = languageSettings.DefaultLanguage;
                foreach (var setting in languageSettings.Settings)
                {
                    AddLang(setting.Language, JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(File.ReadAllText(setting.FilePath)));
                }
            }          
        }

        public static IReadOnlyDictionary<string, Dictionary<string, string>>? GetLang(string language)
        {
            return _i18nCache.GetValueOrDefault(language);
        }

        public LanguageProvider(string? language = null) => SetLang(language ?? DefaultLanguage);

        private string? _CurrentLanguage;

        public string CurrentLanguage
        {
            get
            {
                return _CurrentLanguage ?? DefaultLanguage;
            }
            private set
            {
                _CurrentLanguage = value;
                _languageMap = GetLang(value);
            }
        }

        public IReadOnlyDictionary<string, Dictionary<string, string>>? _languageMap;

        public IReadOnlyDictionary<string, Dictionary<string, string>> LanguageMap
        {
            get
            {
                return _languageMap ?? throw new Exception($"Not has {CurrentLanguage} language !");
            }
            private set
            {
                _languageMap = value;
            }
        }

        public void SetLang(string language) => CurrentLanguage = language;

    }

    internal class LanguageSettings
    {
        public LanguageSettings(string defaultLanguage, Setting[] settings)
        {
            DefaultLanguage = defaultLanguage;
            Settings = settings;
        }

        public string DefaultLanguage { get;set; }

        public Setting[] Settings { get; set; }

        public class Setting
        {
            public Setting(string language, string filePath)
            {
                Language = language;
                FilePath = filePath;
            }

            public string Language { get; set; }

            public string FilePath { get; set; }
        }
    }   
}
