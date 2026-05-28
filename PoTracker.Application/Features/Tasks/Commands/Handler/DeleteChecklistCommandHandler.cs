using MediatR;
using PoTracker.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoTracker.Application.Features.Tasks.Commands.Handler
{
    public class DeleteChecklistCommandHandler : IRequestHandler<DeleteChecklistCommand, bool>
    {
        private readonly AppDbContext _context;

        public DeleteChecklistCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteChecklistCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.ChecklistItems.FindAsync(request.Id);

            if (item == null) return false;

            _context.ChecklistItems.Remove(item);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
