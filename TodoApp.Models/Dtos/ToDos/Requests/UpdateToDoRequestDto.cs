using TodoApp.Models.Enums;

namespace TodoApp.Models.Dtos.ToDos.Requests;

public sealed record UpdateToDoRequestDto(
    Guid Id,
    string Title,
    string Description,
    DateTime StartDate,
    DateTime EndDate,
    bool Completed,
    Priority Priority,
    string UserId
    );

