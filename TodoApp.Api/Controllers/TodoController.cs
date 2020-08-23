using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Features.TodoFeatures.Commands.CreateTodo;
using TodoApp.Application.Features.TodoFeatures.Commands.DeleteTodo;
using TodoApp.Application.Features.TodoFeatures.Commands.UpdateTodo;
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
        public async Task<ActionResult<GetTodoResponse>> Get(Guid id)
        {
            return await _mediator.Send(new GetTodoRequest { Id = id });
        }

        [HttpGet("all")]
        public async Task<ActionResult<GetTodosResponse>> GetAll()
        {
            return await _mediator.Send(new GetTodosRequest());
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTodoRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateTodoRequest request)
        {
            await _mediator.Send(request);

            return NoContent();
        }

        //TODO: Consider patch update

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteTodoRequest { Id = id });

            return NoContent();
        }
    }
}
