using TodoApp.Models.Enums;

namespace TodoApp.Models.Dtos.ToDos.Requests;

public sealed record CreateToDoRequestDto(
    string Title,
    string Description,
    DateTime StartDate,
    DateTime EndDate,
    bool Completed,
    string UserId,
    Priority Priority,
    int CategoryId
    );

