using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using TodoApp.Models.Dtos.ToDos.Requests;
using TodoApp.Models.Entities;
using TodoApp.Service.Abstracts;

namespace TodoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        private readonly IToDoService _todoService;

     
        public ToDosController(IToDoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet("getall")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _todoService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateToDoRequestDto dto, [FromQuery] string userId)
        {
            var result = await _todoService.AddAsync(dto, userId);
            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _todoService.GetByIdAsync(id);
            if (result.Data == null)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var result = await _todoService.RemoveAsync(id);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateToDoRequestDto dto)
        {
            var result = await _todoService.UpdateAsync(dto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("category")]
        public async Task<IActionResult> GetAllByCategoryId([FromQuery] int categoryId)
        {
            var result = await _todoService.GetAllByCategoryIdAsync(categoryId);
            return Ok(result);
        }

        [HttpGet("user")]
        [Authorize]
        public async Task<IActionResult> GetToDosByUser([FromQuery] string userId)
        {
            var result = await _todoService.GetToDosByUserAsync(userId);
            return Ok(result);
        }
    }
}
