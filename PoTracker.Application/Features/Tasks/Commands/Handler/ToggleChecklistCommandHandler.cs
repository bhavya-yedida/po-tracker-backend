using MediatR;
using Microsoft.EntityFrameworkCore;
using PoTracker.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoTracker.Application.Features.Tasks.Commands.Handler
{
    public class ToggleChecklistCommandHandler
    : IRequestHandler<ToggleChecklistCommand, bool>
    {
        private readonly AppDbContext _context;

        public ToggleChecklistCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(
            ToggleChecklistCommand request,
            CancellationToken cancellationToken)
        {
            var item = await _context.ChecklistItems
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (item == null)
                return false;

            item.IsDone = request.IsDone;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
