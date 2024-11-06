using Core.Responses;
using TodoApp.Models.Dtos.ToDos.Requests;
using TodoApp.Models.Dtos.ToDos.Responses;


namespace TodoApp.Service.Abstracts
{
    public interface IToDoService
    {
        Task<ReturnModel<List<ToDoResponseDto>>> GetAllAsync();
        Task<ReturnModel<ToDoResponseDto?>> GetByIdAsync(Guid id);
        Task<ReturnModel<ToDoResponseDto>> AddAsync(CreateToDoRequestDto create,string userId);

        Task<ReturnModel<ToDoResponseDto>> UpdateAsync(UpdateToDoRequestDto updateTodo);

        Task<ReturnModel<ToDoResponseDto>> RemoveAsync(Guid id);

        Task<ReturnModel<List<ToDoResponseDto>>> GetAllByCategoryIdAsync(int id);

        Task<ReturnModel<List<ToDoResponseDto>>> GetToDosByUserAsync(string userId);
      

    }
}
