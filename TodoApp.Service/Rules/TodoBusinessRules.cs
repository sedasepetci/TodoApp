using Core.Exceptions;

using TodoApp.Models.Entities;

namespace TodoApp.Service.Rules;

public class TodoBusinessRules
{

    public virtual void TodoIsNullCheck(ToDo todo)
    {
        if (todo is null)
        {
            throw new NotFoundException("İlgili iş bulunamadı.");
        }
    }
}
