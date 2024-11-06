using AutoMapper;
using Core.Exceptions;
using Core.Responses;
using TodoApp.DataAccess.Abstracts;
using TodoApp.DataAccess.Concretes;
using TodoApp.Models.Dtos.ToDos.Requests;
using TodoApp.Models.Dtos.ToDos.Responses;
using TodoApp.Models.Entities;
using TodoApp.Service.Abstracts;
using TodoApp.Service.Rules;

namespace TodoApp.Service.Concretes;

public sealed class ToDoService : IToDoService
{
    private readonly IToDoRepository _todoRepository;
    private readonly IMapper _mapper;
    private readonly TodoBusinessRules _businessRules;

    public ToDoService(IToDoRepository todoRepository, IMapper mapper,TodoBusinessRules rules)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
        _businessRules = rules;
    }
    public async Task<ReturnModel<ToDoResponseDto>> AddAsync(CreateToDoRequestDto create, string userId)
    {
        try
        {
            ToDo createdTodo = _mapper.Map<ToDo>(create);
            createdTodo.UserId = userId;
            createdTodo.Id = Guid.NewGuid();
           
            await _todoRepository.AddAsync(createdTodo);

            ToDoResponseDto response = _mapper.Map<ToDoResponseDto>(createdTodo);

            return new ReturnModel<ToDoResponseDto>
            {
                Data = response,
                Message = "Yapılacak iş Eklendi.",
                StatusCode = 200,
                Success = true
            };
        }
        catch(Exception e) 
        {
            Console.WriteLine(e.ToString());
            throw new BusinessException(message: e.Message);
        }
        
    }

    public async Task<ReturnModel<List<ToDoResponseDto>>> GetAllAsync()
    {
        List<ToDo> todos = await _todoRepository.GetAllAsync();
        List<ToDoResponseDto> response = _mapper.Map<List<ToDoResponseDto>>(todos);

        return new ReturnModel<List<ToDoResponseDto>>
        {
            Data = response,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }


    public async Task<ReturnModel<List<ToDoResponseDto>>> GetAllByCategoryIdAsync(int id)
    {
        
        var todos = await _todoRepository.GetAllAsync(x => x.CategoryId == id, false);

       
        var responses = _mapper.Map<List<ToDoResponseDto>>(todos);

        
        return new ReturnModel<List<ToDoResponseDto>>
        {
            Data = responses,
            StatusCode = 200,
            Success = true
        };
    }


    public async Task<ReturnModel<ToDoResponseDto?>> GetByIdAsync(Guid id)
    {
       
        var todo = await _todoRepository.GetByIdAsync(id);
        _businessRules.TodoIsNullCheck(todo);
        var response = _mapper.Map<ToDoResponseDto>(todo);
            return new ReturnModel<ToDoResponseDto?>
            {
                Data = response,
                Message = string.Empty,
                StatusCode = 200,
                Success = true
            };
        
    }

    

    public async Task<ReturnModel<List<ToDoResponseDto>>> GetToDosByUserAsync(string id)
    {
       
        var todos = await _todoRepository.GetAllAsync(x => x.UserId == id, false);

        
        var response = _mapper.Map<List<ToDoResponseDto>>(todos);

        return new ReturnModel<List<ToDoResponseDto>>
        {
            Data = response,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }

    public async Task<ReturnModel<ToDoResponseDto>> RemoveAsync(Guid id)
    {
        
        var todo = await _todoRepository.GetByIdAsync(id);

        _businessRules.TodoIsNullCheck(todo);


        var deletedTodo = await _todoRepository.RemoveAsync(todo);

       
        var response = _mapper.Map<ToDoResponseDto>(deletedTodo);

        return new ReturnModel<ToDoResponseDto>
        {
            Data = response,
            Message = "Yapılacak iş silindi.",
            StatusCode = 200,
            Success = true
        };
    }


    public async Task<ReturnModel<ToDoResponseDto>> UpdateAsync(UpdateToDoRequestDto updateTodo)
    {
       
        var todo = await _todoRepository.GetByIdAsync(updateTodo.Id);

        _businessRules.TodoIsNullCheck(todo);


        todo.Title = updateTodo.Title;
        todo.Description = updateTodo.Description;
        todo.StartDate = updateTodo.StartDate;
        todo.EndDate = updateTodo.EndDate;
        todo.Priority = updateTodo.Priority;
        todo.Completed = updateTodo.Completed;
        todo.UserId = updateTodo.UserId;

       
        var updatedTodo = await _todoRepository.UpdateAsync(todo);

       
        var response = _mapper.Map<ToDoResponseDto>(updatedTodo);

        return new ReturnModel<ToDoResponseDto>
        {
            Data = response,
            Message = "Yapılacak iş güncellendi.",
            StatusCode = 200,
            Success = true
        };
    }

  
}

