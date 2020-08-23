using FluentValidation;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.DataAccess.Repositories.Todos;

namespace TodoApp.Application.Features.TodoFeatures.Commands.UpdateTodo
{
    public class UpdateTodoValidator : AbstractValidator<UpdateTodoRequest>
    {
        private readonly ITodoRepository _repository;

        public UpdateTodoValidator(ITodoRepository repository)
        {
            _repository = repository;

            RuleFor(v => v.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(50).WithMessage("Title must not exceed 50 characters.")
                .MustAsync(BeUniqueTitle).WithMessage("Title must be unique.");
        }

        public async Task<bool> BeUniqueTitle(UpdateTodoRequest model, string title, CancellationToken cancellationToken)
        {
            var todos = await _repository.GetTodos(cancellationToken);

            return todos.Where(td => td.Id != model.Id)
                .All(td => td.Title != title);
        }
    }
}
