using System.ComponentModel.DataAnnotations;
using SQLite;

namespace Masa.Blazor.Pro.Components.Models;

public class TodoTask
{
    private int[] _tagIds = [];

    public TodoTask()
    {
        DueAt = DateTime.Today;
    }

    [PrimaryKey, AutoIncrement] public int Id { get; set; }

    [Required] [Indexed] public string? Title { get; set; }

    public string? Description { get; set; }

    [Required] public DateTime DueAt { get; set; }

    public TodoTaskPriority Priority { get; set; }

    public bool Important { get; set; }

    public bool Completed { get; set; }

    [Ignore]
    public int[] TagIds
    {
        get => Tags?.Split(';').Where(t => !string.IsNullOrEmpty(t)).Select(int.Parse).ToArray() ?? [];
        set
        {
            Tags = string.Join(';', value);
            if (Tags.Length > 0)
            {
                Tags += ";";
            }
        }
    }

    public string? Tags { get; private set; }
}

public enum TodoTaskPriority
{
    Default,
    Low,
    Medium,
    High
}