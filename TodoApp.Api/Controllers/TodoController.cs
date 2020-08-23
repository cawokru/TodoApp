using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(typeof(GetTodoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetTodoResponse>> Get(Guid id)
        {
            return await _mediator.Send(new GetTodoRequest { Id = id });
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(GetTodosResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetTodosResponse>> GetAll()
        {
            return await _mediator.Send(new GetTodosRequest());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTodoRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Update([FromBody] UpdateTodoRequest request)
        {
            await _mediator.Send(request);

            return NoContent();
        }

        //TODO: Consider patch update

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteTodoRequest { Id = id });

            return NoContent();
        }
    }
}
