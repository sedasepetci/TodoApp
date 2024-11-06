using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Models.Dtos.ToDos.Requests;

namespace TodoApp.Service.Validations.ToDos
{
    public class UpdateTodoRequestValidator : AbstractValidator<UpdateToDoRequestDto>

    {
        public UpdateTodoRequestValidator()
        {
            RuleFor(x => x.Description)
    .MaximumLength(500).WithMessage("Description en fazla 500 karakter olmalıdır.")
    .When(x => !string.IsNullOrEmpty(x.Description));
            RuleFor(x => x.Completed)
           .NotNull().WithMessage("Tamamlanma durumu belirtilmelidir.");
            RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId boş olamaz.")
            .Length(36).WithMessage("Geçersiz UserId formatı.");
            
            RuleFor(x => x.Priority).IsInEnum().WithMessage("Geçersiz öncelik değeri.");
            
        }

    }
}
