using MediatR;
using Microsoft.EntityFrameworkCore;
using PoTracker.Domain.Entities;
using PoTracker.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoTracker.Application.Features.Tasks.Queries.Handler
{
    public class GetChecklistQueryHandler
    : IRequestHandler<GetChecklistQuery, List<ChecklistItem>>
    {
        private readonly AppDbContext _context;

        public GetChecklistQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ChecklistItem>> Handle(
            GetChecklistQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.ChecklistItems
                .ToListAsync(cancellationToken);
        }
    }
}
