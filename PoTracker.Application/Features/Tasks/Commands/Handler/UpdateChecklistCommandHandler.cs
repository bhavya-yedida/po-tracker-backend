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
    public class UpdateChecklistCommandHandler : IRequestHandler<UpdateChecklistCommand, ChecklistItem?>
    {
        private readonly AppDbContext _context;

        public UpdateChecklistCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ChecklistItem?> Handle(UpdateChecklistCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.ChecklistItems.FindAsync(request.Id);

            if (item == null) return null;

            item.Title = request.Title;
            item.IsDone = request.IsDone;

            await _context.SaveChangesAsync(cancellationToken);

            return item;
        }
    }
}
