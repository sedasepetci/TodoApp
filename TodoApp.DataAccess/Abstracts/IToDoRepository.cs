

using Core.Repositories;
using TodoApp.Models.Entities;

namespace TodoApp.DataAccess.Abstracts;

public interface IToDoRepository:IRepository<ToDo, Guid>
{
}
