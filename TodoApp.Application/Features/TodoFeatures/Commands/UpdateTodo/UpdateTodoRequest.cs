using MediatR;
using System;
using TodoApp.Domain.Enums;

namespace TodoApp.Application.Features.TodoFeatures.Commands.UpdateTodo
{
    public class UpdateTodoRequest: IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public int Priority { get; set; } = (int)PriorityLevel.Medium; //TODO: Review priority implementation
    }
}
