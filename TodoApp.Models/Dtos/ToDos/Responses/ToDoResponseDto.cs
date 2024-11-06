using TodoApp.Models.Enums;

namespace TodoApp.Models.Dtos.ToDos.Responses;

public sealed record ToDoResponseDto
{
    public string Title { get; init; } = default!;
    public string Description { get; init; } = default!;
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public Priority Priority { get; init; }
    

}

