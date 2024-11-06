
using TodoApp.Models.Dtos.Tokens.Responses;
using TodoApp.Models.Entities;

namespace TodoApp.Service.Abstracts;

public interface IJwtService
{
    Task<TokenResponseDto> CreateJwtTokenAsync(User user);
}
