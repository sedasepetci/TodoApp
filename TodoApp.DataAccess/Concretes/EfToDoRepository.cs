
using Core.Repositories;
using TodoApp.DataAccess.Abstracts;
using TodoApp.DataAccess.Contexts;
using TodoApp.Models.Entities;

namespace TodoApp.DataAccess.Concretes;

public class EfToDoRepository:EfRepositoryBase<BaseDbContext,ToDo,Guid>, IToDoRepository
{
    public EfToDoRepository(BaseDbContext context) : base(context)
    {
    }
}
