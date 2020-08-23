using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.DataAccess.Repositories.Todos;

namespace TodoApp.Application.Features.TodoFeatures.Commands.CreateTodo
{
    public class CreateTodoValidator : AbstractValidator<CreateTodoRequest>
    {
        private readonly ITodoRepository _repository;

        public CreateTodoValidator(ITodoRepository repository)
        {
            _repository = repository;

            //TODO: Implement translation service
            RuleFor(v => v.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(50).WithMessage("Title must not exceed 50 characters.")
                .MustAsync(BeUniqueTitle).WithMessage("Task should have unique title.");

            RuleFor(v => v.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(50).WithMessage("Description must not exceed 255 characters.");
        }

        public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
        {
            var todos = await _repository.GetTodos(cancellationToken);

            return !todos.Any(td => td.Title == title);
        }
    }
}
