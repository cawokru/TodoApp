using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.DataAccess.Repositories.Todos;
using TodoApp.Domain.Enums;

namespace TodoApp.Application.Features.TodoFeatures.Commands.UpdateTodo
{
    class UpdateTodoHandler : IRequestHandler<UpdateTodoRequest>
    {
        private readonly ITodoRepository _repository;

        public UpdateTodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateTodoRequest request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetTodoById(request.Id, cancellationToken);

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.Done = request.Done;
            entity.Priority = (PriorityLevel)request.Priority;
            entity.ModifiedOn = DateTime.Now; //TODO: Implenet date provider and current user provider

            await _repository.UpdateTodo(entity, cancellationToken);

            return Unit.Value;
        }
    }
}
