using MediatR;
using System;

namespace TodoApp.Application.Features.TodoFeatures.Queries.GetTodoById
{
    public class GetTodoRequest: IRequest<GetTodoResponse>
    {
        public Guid Id { get; set; }
    }
}
