using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PoTracker.Application.Features.Tasks.Commands;
using PoTracker.Application.Features.Tasks.Queries;

namespace PoTracker.Api.Controllers
{
    [ApiController]
    [Route("api/checklist")]
    public class ChecklistController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChecklistController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetChecklistQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateChecklistCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("toggle/{id}")]
        public async Task<IActionResult> Toggle(int id)
        {
            return Ok(await _mediator.Send(new ToggleChecklistCommand
            {
                Id = id
            }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateChecklistCommand command)
        {
            command.Id = id;

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteChecklistCommand
            {
                Id = id
            }));
        }
    }
}