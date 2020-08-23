using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.DataAccess.Repositories.Todos;

namespace TodoApp.Application.Features.TodoFeatures.Queries.GetTodos
{
    public class GetTodosHandler : IRequestHandler<GetTodosRequest, GetTodosResponse>
    {
        private readonly ITodoRepository _repository;

        public GetTodosHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetTodosResponse> Handle(GetTodosRequest request, CancellationToken cancellationToken)
        {
            return new GetTodosResponse
            {
                Todos = await _repository.GetTodos(cancellationToken)
            };
        }
    }
}
