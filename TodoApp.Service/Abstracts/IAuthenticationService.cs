
using Core.Responses;
using TodoApp.Models.Dtos.Tokens.Responses;
using TodoApp.Models.Dtos.Users.Requests;

namespace TodoApp.Service.Abstracts;


public interface IAuthenticationService
{
    Task<ReturnModel<TokenResponseDto>> LoginAsync(LoginRequestDto dto);
    Task<ReturnModel<TokenResponseDto>> RegisterAsync(RegisterRequestDto dto);
}