using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.DataAccess.Repositories.Todos;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Enums;

namespace TodoApp.Application.Features.TodoFeatures.Commands.CreateTodo
{
    class CreateTodoHandler : IRequestHandler<CreateTodoRequest, Guid>
    {
        private readonly ITodoRepository _repository;

        public CreateTodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateTodoRequest request, CancellationToken cancellationToken)
        {
            var dateNow = DateTime.Now; //TODO: Provide date service
            var currentUser = "Alex"; //TODO: Retrieve current user from context

            var todo = new Todo
            {
                Title = request.Title,
                Description = request.Description,
                Done = false,
                Priority = PriorityLevel.Medium,
                CreatedBy = currentUser,
                ModifiedBy = currentUser,
                CreatedOn = dateNow,
                ModifiedOn = dateNow
            };

            await _repository.CreateTodo(todo, cancellationToken);

            return todo.Id;
        }
    }
}
