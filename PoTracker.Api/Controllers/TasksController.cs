using MediatR;
using Microsoft.AspNetCore.Mvc;
using PoTracker.Application.Features.Tasks.Commands.CreateTask;
using PoTracker.Application.Features.Tasks.Commands.UpdateTask;
using PoTracker.Application.Features.Tasks.Commands.DeleteTask;
using PoTracker.Application.Features.Tasks.Queries;

namespace PoTracker.Api.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var tasks = await _mediator.Send(new GetTasksQuery());
        return Ok(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTaskCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateTaskCommand command)
    {
        var result = await _mediator.Send(command);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteTaskCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result)
            return NotFound();

        return Ok(result);
    }
}