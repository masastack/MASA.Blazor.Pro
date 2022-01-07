namespace MASA.Blazor.Pro.Data.App.User.Dto;

public class UserDto
{
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
    public string Role { get; set; } = "Subscriber";

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

    public DateOnly BirthDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    public string? Mobile { get; set; } = "(895) 401-4255";

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

    public List<PermissionDto> Permissions { get; set; }

    internal string Color { get; }

    public UserDto()
    {
        Id = Guid.NewGuid().ToString();
        Random _ran = new Random();

        List<string> _colors = new List<string>
        {
            "error", "pry", "remind", "info", "sample-green"
        };
        int index = _ran.Next(0, 5);
        Color = _colors[index];

        Permissions = new List<PermissionDto>()
        {
            new PermissionDto() { Module="Admin", Read = true },
            new PermissionDto() { Module="Staff", Write = true },
            new PermissionDto() { Module="Author", Read = true, Create = true },
            new PermissionDto() { Module="Contributor" },
            new PermissionDto() { Module="User", Delete = true },
        };
    }

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
