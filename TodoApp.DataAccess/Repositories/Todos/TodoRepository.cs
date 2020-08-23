using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.DataAccess.Exceptions;
using TodoApp.Domain.Entities;

namespace TodoApp.DataAccess.Repositories.Todos
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ITodoContext _context;

        public TodoRepository(ITodoContext context)
        {
            _context = context;
        }

        public async Task<Todo> GetTodoById(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _context.Todos
                .AsNoTracking()
                .SingleOrDefaultAsync(td => td.Id == id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Todo), id);
            }

            return entity;
        }

        //TODO: Get tasks by user
        public async Task<IEnumerable<Todo>> GetTodos(CancellationToken cancellation)
        {
            return await _context.Todos
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Todo> CreateTodo(Todo todo, CancellationToken cancellationToken)
        {
            _context.Todos.Add(todo);

            await _context.SaveChangesAsync(cancellationToken);

            return todo;
        }

        public async Task<Todo> UpdateTodo(Todo todo, CancellationToken cancellationToken)
        {
            _context.Entry(todo).State = EntityState.Modified;

            await _context.SaveChangesAsync(cancellationToken);

            return todo;
        }

        public async Task<Todo> DeleteTodo(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _context.Todos
                .SingleOrDefaultAsync(td => td.Id == id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Todo), id);
            }

            _context.Todos.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
