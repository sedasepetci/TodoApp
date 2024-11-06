using Core.Responses;
using TodoApp.Models.Dtos.Tokens.Responses;
using TodoApp.Models.Dtos.Users.Requests;
using TodoApp.Service.Abstracts;

namespace TodoApp.Service.Concretes
{
    public class AuthenticationService(IUserService _userService, IJwtService _jwtService) : IAuthenticationService
    {
        public async Task<ReturnModel<TokenResponseDto>> LoginAsync(LoginRequestDto request)
        {
            var user = await _userService.LoginAsync(request);
            var tokenResponse = await _jwtService.CreateJwtTokenAsync(user);

            return new ReturnModel<TokenResponseDto>()
            {
                Data = tokenResponse,
                Message = "Giriş Başarılı.",
                StatusCode = 200,
                Success = true
            };
        }

        public async Task<ReturnModel<TokenResponseDto>> RegisterAsync(RegisterRequestDto request)
        {
            var user = await _userService.RegisterAsync(request);
            var tokenResponse = await _jwtService.CreateJwtTokenAsync(user);

            return new ReturnModel<TokenResponseDto>()
            {
                Data = tokenResponse,
                Message = "Giriş Başarılı.",
                StatusCode = 200,
                Success = true
            };
        }
    }
}
