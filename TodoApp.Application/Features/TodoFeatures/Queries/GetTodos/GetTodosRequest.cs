using MediatR;

namespace TodoApp.Application.Features.TodoFeatures.Queries.GetTodos
{
    public class GetTodosRequest : IRequest<GetTodosResponse> { }
}
