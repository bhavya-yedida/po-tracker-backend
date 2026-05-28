using MediatR;
using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetNotesQueryHandler(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<Note>> Handle(
            GetNotesQuery request,
            CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(_httpContextAccessor.HttpContext!.User.FindFirst("userId")!.Value);

            return await _context.Notes.Where(t => t.UserId == userId)
                .OrderByDescending(x => x.UpdatedAt)
                .ToListAsync(cancellationToken);
        }
    }
}
