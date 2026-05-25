using MediatR;
using Microsoft.AspNetCore.Mvc;
using PoTracker.Application.Features.Tasks.Commands;
using PoTracker.Application.Features.Tasks.Commands.Handler;
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
        public async Task<IActionResult> Create(CreateChecklistCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("toggle")]
        public async Task<IActionResult> Toggle(ToggleChecklistCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
