using System.Collections.Generic;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Features.TodoFeatures.Queries.GetTodos
{
    public class GetTodosResponse
    {
        public IEnumerable<Todo> Todos { get; set; }
    }
}
