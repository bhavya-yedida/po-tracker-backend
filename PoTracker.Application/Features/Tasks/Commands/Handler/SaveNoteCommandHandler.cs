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
    public class SaveNoteCommandHandler
    : IRequestHandler<SaveNoteCommand, Note>
    {
        private readonly AppDbContext _context;

        public SaveNoteCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Note> Handle(
            SaveNoteCommand request,
            CancellationToken cancellationToken)
        {
            var note = new Note
            {
                Content = request.Content,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Notes.Add(note);
            await _context.SaveChangesAsync(cancellationToken);

            return note;
        }
    }
}
