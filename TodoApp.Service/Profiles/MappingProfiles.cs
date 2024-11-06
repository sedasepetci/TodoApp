
using AutoMapper;
using TodoApp.Models.Dtos.Categories.Requests;
using TodoApp.Models.Dtos.Categories.Responses;
using TodoApp.Models.Dtos.ToDos.Requests;
using TodoApp.Models.Dtos.ToDos.Responses;
using TodoApp.Models.Entities;

namespace TodoApp.Service.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateToDoRequestDto, ToDo>();
        CreateMap<UpdateToDoRequestDto, ToDo>();
        CreateMap<ToDo, ToDoResponseDto>();

        CreateMap<CreateCategoryRequestDto, ToDo>();
        CreateMap<UpdateCategoryRequestDto, ToDo>();
        CreateMap<Category,CategoryResponseDto>();
        
       
         
    }
}