using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using TodoApp.DataAccess.Exceptions;

namespace TodoApp.Common.Web.Filters
{
    //TODO: Remove "magic" values
    public class ApiExceptionFilterAttribute : ApiExceptionBaseFilterAttribute
    {
        public ApiExceptionFilterAttribute(): base()
        {
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(ValidationException), HandleValidationException },
                { typeof(NotFoundException), HandleNotFoundException },
            };
        }

        private void HandleValidationException(ExceptionContext context)
        {
            var exception = context.Exception as ValidationException;

            var failureGroups = exception.Errors
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage);

            var details = new ValidationProblemDetails(failureGroups.ToDictionary(fg => fg.Key, fg => fg.ToArray()))
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
            };

            context.Result = new BadRequestObjectResult(details);

            context.ExceptionHandled = true;
        }

        private void HandleNotFoundException(ExceptionContext context)
        {
            var exception = context.Exception as NotFoundException;

            var details = new ProblemDetails()
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = "The specified resource was not found.",
                Detail = exception.Message
            };

            context.Result = new NotFoundObjectResult(details);

            context.ExceptionHandled = true;
        }
    }
}
