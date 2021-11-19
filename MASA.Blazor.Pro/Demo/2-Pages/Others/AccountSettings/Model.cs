namespace MASA.Blazor.Pro.Demo._2_Pages.Others.AccountSettings
{
    public class UserInfo
    {
        public UserInfo(string userName, string name, string email, string company)
        {
            UserName = userName;
            Name = name;
            Email = email;
            Company = company;
        }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Company { get; set; }

        public UserInfo Clone()
        {
            return (UserInfo)base.MemberwiseClone();
        }
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
        public Information()
        {
            Bio = "";
            Website = "";
        }
        public Information(string bio, DateOnly birthDate, string country, string website, long? phone)
        {
            Bio = bio;
            BirthDate = birthDate;
            Country = country;
            Website = website;
            Phone = phone;
        }

        public string Bio { get; set; }

        public DateOnly BirthDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public string Country { get; set; } = "1";

        public string Website { get; set; }

        public long? Phone { get; set; } = 6562542568;

        public void Reset()
        {
            Bio = "";
            Website = "";
            BirthDate= DateOnly.FromDateTime(DateTime.Now);
            Country = "1";
            Phone = 6562542568;
        }
    }
}
