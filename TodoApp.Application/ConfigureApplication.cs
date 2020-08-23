using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TodoApp.Common.Web.Middlewares;

namespace TodoApp.Application
{
    public static class ConfigureApplication
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationMiddleware<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionMiddleware<,>));

            return services;
        }
    }
}
