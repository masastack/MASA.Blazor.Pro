namespace MASA.Blazor.Pro.Global
{
    public class LanguageSetting
    {
        public LanguageSetting(string text, string value, string filePath, bool isDefaultLanguage=false)
        {
            Text = text;
            Value = value;  
            FilePath = filePath;
            IsDefaultLanguage = isDefaultLanguage;
        }
        public string Text { get; set; }

        public string Value { get; set; }

        public string FilePath { get; set; }

        public bool IsDefaultLanguage { get; set; }
    }
}
