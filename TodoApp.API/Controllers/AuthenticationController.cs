using Core.Tokens.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Models.Dtos.Users.Requests;
using TodoApp.Service.Abstracts;

namespace TodoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IAuthenticationService _authenticationService) : ControllerBase
    {

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            var result = await _authenticationService.LoginAsync(dto);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
        {
            var result = await _authenticationService.RegisterAsync(dto);
            return Ok(result);
        }
    }
}
