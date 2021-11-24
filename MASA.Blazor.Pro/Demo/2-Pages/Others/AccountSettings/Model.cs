namespace MASA.Blazor.Pro.Demo._2_Pages.Others.AccountSettings
{
    public class UserInfo
    {

        public string UserName { get; set; } = "johndoe";

        public string Name { get; set; } = "John Doe";

        public string Email { get; set; } = "granger007@hogward.com";

        public string Company { get; set; } = "Crystal Technologies";

    }

    public class Item
    {
        public string Label { get; set; }
        public string Value { get; set; }
        public Item(string label, string value)
        {
            Label = label;
            Value = value;
        }
    }

    public class Information
    {
        public string Bio { get; set; } = "";

        public DateOnly BirthDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public string Country { get; set; } = "1";

        public string Website { get; set; } = "";

        public long? Phone { get; set; } = 6562542568;
    }

    public class Social
    {
        public string Twitter { get; set; } = "https://www.twitter.com";

        public string Facebook { get; set; } = "";

        public string Google { get; set; } = "";

        public string LinkedIn { get; set; } = "https://www.linkedin.com";

        public string Instagram { get; set; } = "";

        public string Quora { get; set; } = "";
    }
}
