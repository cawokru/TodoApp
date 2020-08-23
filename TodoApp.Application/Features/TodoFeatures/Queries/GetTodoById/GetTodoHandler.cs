using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.DataAccess.Repositories.Todos;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Features.TodoFeatures.Queries.GetTodoById
{
    class GetTodoHandler : IRequestHandler<GetTodoRequest, GetTodoResponse>
    {
        private readonly ITodoRepository _repository;
        private readonly IMapper _mapper;

        public GetTodoHandler(ITodoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetTodoResponse> Handle(GetTodoRequest request, CancellationToken cancellationToken)
        {
            var todo = await _repository.GetTodoById(request.Id, cancellationToken);

            return _mapper.Map<Todo, GetTodoResponse> (todo);
        }
    }
}
