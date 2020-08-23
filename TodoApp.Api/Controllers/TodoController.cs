using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Features.TodoFeatures.Queries.GetTodoById;
using TodoApp.Application.Features.TodoFeatures.Queries.GetTodos;

namespace TodoApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ApiBaseController
    {
        private readonly IMediator _mediator;

        public TodoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        public async Task<GetTodoResponse> Get(Guid id)
        {
            return await _mediator.Send(new GetTodoRequest { Id = id });
        }

        [HttpGet("all")]
        public async Task<GetTodosResponse> GetTodos()
        {
            return await _mediator.Send(new GetTodosRequest());
        }
    }
}
