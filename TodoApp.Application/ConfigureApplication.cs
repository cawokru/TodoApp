using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TodoApp.Application
{
    public static class ConfigureApplication
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
