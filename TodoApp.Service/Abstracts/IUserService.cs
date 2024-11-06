
using TodoApp.Models.Dtos.Users.Requests;
using TodoApp.Models.Entities;

namespace TodoApp.Service.Abstracts;

public interface IUserService
{
    Task<User> RegisterAsync(RegisterRequestDto request);
    Task<User> GetByEmailAsync(string email);
    Task<User> LoginAsync(LoginRequestDto request);
    Task<User> UpdateAsync(string id, UserUpdateRequestDto request);
    Task<string> DeleteAsync(string id);
    Task<User> ChangePasswordAsync(string id, ChangePasswordRequestDto request);
}
