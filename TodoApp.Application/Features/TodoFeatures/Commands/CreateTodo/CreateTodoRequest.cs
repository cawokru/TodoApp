using MediatR;
using System;

namespace TodoApp.Application.Features.TodoFeatures.Commands.CreateTodo
{
    public class CreateTodoRequest : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
