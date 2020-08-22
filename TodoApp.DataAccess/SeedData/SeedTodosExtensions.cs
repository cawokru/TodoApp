using System;
using System.Linq;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Enums;

namespace TodoApp.DataAccess.SeedData
{
    public static class SeedTodosExtensions
    {
        public static void SeedTodos(this TodoContext context)
        {
            if (!context.Todos.Any())
            {
                var dateNow = DateTime.Now;

                context.Todos.Add(new Todo
                {
                    Title = "Make cofee",
                    Description = "Don't forget to buy coffee first",
                    Done = false,
                    Priority = PriorityLevel.Medium,
                    CreatedBy = "Alex",
                    CreatedOn = dateNow,
                    ModifiedBy = "Alex",
                    ModifiedOn = dateNow
                });

                context.Todos.Add(new Todo
                {
                    Title = "Buy Milk",
                    Description = "buy sime milk for those who likes white coffee",
                    Done = true,
                    Priority = PriorityLevel.High,
                    CreatedBy = "Alex",
                    CreatedOn = dateNow,
                    ModifiedBy = "Alex",
                    ModifiedOn = dateNow
                });

                context.SaveChanges();
            }
        }
    }
}
