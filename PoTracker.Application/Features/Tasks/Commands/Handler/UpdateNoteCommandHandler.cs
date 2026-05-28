using MediatR;
using PoTracker.Domain.Entities;
using PoTracker.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoTracker.Application.Features.Tasks.Commands.Handler
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, Note?>
    {
        private readonly AppDbContext _context;

        public UpdateNoteCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Note?> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = await _context.Notes.FindAsync(request.Id);

            if (note == null)
                return null;

            note.Content = request.Content;
            note.Tags = request.Tags;
            note.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return note;
        }
    }
}
