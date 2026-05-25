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
    public class GetNotesQueryHandler
    : IRequestHandler<GetNotesQuery, List<Note>>
    {
        private readonly AppDbContext _context;

        public GetNotesQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Note>> Handle(
            GetNotesQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Notes
                .OrderByDescending(x => x.UpdatedAt)
                .ToListAsync(cancellationToken);
        }
    }
}
