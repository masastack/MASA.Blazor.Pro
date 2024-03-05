using System.ComponentModel.DataAnnotations;
using SQLite;

namespace Masa.Blazor.ProApp.Rcl.Models;

public class TodoTask
{
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

    public string? Tags { get; set; }
}

public enum TodoTaskPriority
{
    Default,
    Low,
    Medium,
    High
}