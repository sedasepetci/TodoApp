namespace TodoApp.Models.Dtos.Users.Requests;

public sealed record RegisterRequestDto
    (
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string Username,
    string City
    );