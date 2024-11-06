

using Microsoft.AspNetCore.Identity;

namespace TodoApp.Models.Entities;

public class User: IdentityUser
{

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public DateTime BirthDate { get; set; }
    public string City { get; set; } = default!;

    public List<ToDo> ToDos { get; set; }

    
}
