using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.DataAccess.Repositories.Todos;

namespace TodoApp.Application.Features.TodoFeatures.Commands.DeleteTodo
{
    class DeleteTodoHandler : IRequestHandler<DeleteTodoRequest>
    {
        private readonly ITodoRepository _repository;

        public DeleteTodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteTodoRequest request, CancellationToken cancellationToken)
        {
            await _repository.DeleteTodo(request.Id, cancellationToken);

            return Unit.Value;
        }
    }
}
