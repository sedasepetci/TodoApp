using Core.Entities;
using System.Reflection.Metadata;
using TodoApp.Models.Enums;

namespace TodoApp.Models.Entities;

public sealed class ToDo : Entity<Guid>
{
   
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Priority Priority { get; set; }
    public int CategoryId { get; set; }
    public bool Completed { get; set; }
    public Category Category { get; set; } = null!;
    public string UserId { get; set; } = default!;
    public User User { get; set; } = default!;
}
