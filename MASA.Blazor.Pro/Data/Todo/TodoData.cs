namespace MASA.Blazor.Pro.Data;

public class TodoData
{
    public int Id { get; set; }

    public bool IsChecked { get; set; }

    public bool IsImportant { get; set; }

    public bool IsCompleted { get; set; }

    public bool IsDeleted { get; set; }

    [Required]
    public string Title { get; set; } = "";

    public string Assignee { get; set; } = "";

    public int Avatar { get; set; }

    public DateOnly DueDate { get; set; } = new DateOnly(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

    [Required]
    public List<string> Tag { get; set; } = new List<string>();

    public string? Description { get; set; }
}

