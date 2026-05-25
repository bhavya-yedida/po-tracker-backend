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
    public class CreateChecklistCommandHandler
    : IRequestHandler<CreateChecklistCommand, ChecklistItem>
    {
        private readonly AppDbContext _context;

        public CreateChecklistCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ChecklistItem> Handle(
            CreateChecklistCommand request,
            CancellationToken cancellationToken)
        {
            var item = new ChecklistItem
            {
                Title = request.Title,
                Phase = request.Phase,
                IsDone = false
            };

            _context.ChecklistItems.Add(item);
            await _context.SaveChangesAsync(cancellationToken);

            return item;
        }
    }
}
