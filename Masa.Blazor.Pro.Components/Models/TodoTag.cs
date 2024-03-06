using SQLite;

namespace Masa.Blazor.Pro.Components.Models;

public class TodoTag
{
    [PrimaryKey] [AutoIncrement] public int Id { get; set; }

    public string? Name { get; set; }

    public string? Color { get; set; }
}