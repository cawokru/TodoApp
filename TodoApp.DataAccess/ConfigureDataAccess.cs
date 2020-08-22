using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using TodoApp.DataAccess.Repositories.Todos;
using TodoApp.DataAccess.SeedData;

namespace TodoApp.DataAccess
{
    public static class ConfigureDataAccess
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, Action<TodoContextOptions> options)
        {
            var todoContextOptions = new TodoContextOptions();

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            options.Invoke(todoContextOptions);

            if (todoContextOptions.UseInMemoryDb)
            {
                services.AddDbContext<TodoContext>(options =>
                    options.UseInMemoryDatabase(todoContextOptions.DefaultDbName));
            }
            else
            {
                services.AddDbContext<TodoContext>(opt =>
                    opt.UseSqlServer(
                        todoContextOptions.ConnectionString,
                        b => b.MigrationsAssembly(typeof(TodoContext).Assembly.FullName)));
            }

            services.AddScoped<ITodoContext>(provider => provider.GetService<TodoContext>());

            services.AddTransient<ITodoRepository, TodoRepository>();

            return services;
        }

        public static void SeedDatabase(this IServiceProvider services) => SeedDataHelper.SeedDatabase(services.GetRequiredService<TodoContext>());
    }
}
