namespace MASA.Blazor.Pro.Data.User;

public class UserData
{
    public UserData()
    {
        Id = Guid.NewGuid().ToString();
        Random _ran = new Random();

        List<string> _colors = new List<string>
            {
                "red", "deep-purple", "orange", "cyan", "green","blue-grey"
            };
        int index = _ran.Next(0, 6);
        Color = _colors[index];

        Permissions = new List<Permission>()
        {
            new Permission() { Module="Admin", Read = true },
            new Permission() { Module="Staff", Write = true },
            new Permission() { Module="Author", Read = true, Create = true },
            new Permission() { Module="Contributor" },
            new Permission() { Module="User", Delete = true },
        };
    }

    public string Id { get; set; }

    public string? HeadImg { get; set; }

    [Required]
    public string? UserName { get; set; }

    [Required]
    public string FullName { get; set; } = "";

    public string? SampleName
    {
        get
        {
            return string.Join("", FullName.Split(' ').Select(n => n[0].ToString().ToUpper()));
        }
    }

    public string Status { get; set; } = "Pending";

    [Required]
    public string? Role { get; set; }

    [Required]
    public string? Plan { get; set; }

    [Required]
    public string? Country { get; set; }

    [Required]
    public string? Contact { get; set; }

    [Required]
    public string? Company { get; set; }

    public string? Sales { get; set; }

    public string? Profit { get; set; }

    public string? Email { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? Mobile { get; set; }

    public string? Website { get; set; }

    public string? Language { get; set; }

    public string Gender { get; set; } = "Male";

    public string? ContactOptions { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? Address3 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Twitter { get; set; }

    public string? Facebook { get; set; }

    public string? Instagram { get; set; }

    public string? Github { get; set; }

    public string? Codepen { get; set; }

    public string? Slack { get; set; }


    public List<Permission> Permissions { get; set; }

    internal string Color { get; }

    public string GetFullNameInitials()
    {
        var result = "";
        foreach (var item in FullName.Split(' ', '.'))
        {
            result += item.Substring(0, 1);
        }
        return result;
    }
}

public class Permission
{
    public string Module { get; set; } = default!;

    public bool Read { get; set; }

    public bool Write { get; set; }

    public bool Create { get; set; }

    public bool Delete { get; set; }
}