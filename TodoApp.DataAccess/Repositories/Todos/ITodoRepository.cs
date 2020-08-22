using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.DataAccess.Repositories.Todos
{
    public interface ITodoRepository
    {
        Task<Todo> GetTodoById(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Todo>> GetTodos(CancellationToken cancellation);
        Task<Todo> CreateTodo(Todo todo, CancellationToken cancellationToken);
        Task<Todo> UpdateTodo(Todo todo, CancellationToken cancellationToken);
        Task<Todo> DeleteTodo(Guid id, CancellationToken cancellationToken);
    }
}
