using MediatR;
using Microsoft.AspNetCore.Http;
using PoTracker.Domain.Entities;
using PoTracker.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoTracker.Application.Features.Tasks.Commands.Handler
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Note>
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateNoteCommandHandler(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Note> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(
                _httpContextAccessor.HttpContext!.User.FindFirst("userId")!.Value
            );

            var note = new Note
            {
                Content = request.Content,
                Tags = request.Tags,
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null
            };

            _context.Notes.Add(note);
            await _context.SaveChangesAsync(cancellationToken);

            return note;
        }
    }
}
