using MediatR;
using Microsoft.AspNetCore.Mvc;
using PoTracker.Application.Features.Tasks.Commands;
using PoTracker.Application.Features.Tasks.Queries;

namespace PoTracker.Api.Controllers
{
    [ApiController]
    [Route("api/notes")]
    public class NotesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetNotesQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Save(SaveNoteCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
