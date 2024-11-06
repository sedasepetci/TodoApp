using Core.Entities;

namespace TodoApp.Models.Entities;

public sealed class Category : Entity<int>
{
    public string Name { get; set; } = default!;
    public List<ToDo> ToDos { get; set; }
}
