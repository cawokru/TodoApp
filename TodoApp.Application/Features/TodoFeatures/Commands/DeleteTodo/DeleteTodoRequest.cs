using MediatR;
using System;

namespace TodoApp.Application.Features.TodoFeatures.Commands.DeleteTodo
{
    public class DeleteTodoRequest: IRequest
    {
        public Guid Id { get; set; }
    }
}
