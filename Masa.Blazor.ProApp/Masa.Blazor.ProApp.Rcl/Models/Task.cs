using System.ComponentModel.DataAnnotations;

namespace Masa.Blazor.ProApp.Rcl.Models;

public class TodoTask
{
    public int Id { get; set; }

    [Required] public string? Title { get; set; }

    public string? Description { get; set; }

    [Required] public DateOnly DueAt { get; set; }

    public bool Important { get; set; }

    public bool Done { get; set; }

    public bool Deleted { get; set; }

    public string[] Tags { get; set; } = [];
}