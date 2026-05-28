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
    public class GetChecklistQueryHandler : IRequestHandler<GetChecklistQuery, List<ChecklistItem>>
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetChecklistQueryHandler(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<ChecklistItem>> Handle(GetChecklistQuery request, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(_httpContextAccessor.HttpContext!.User.FindFirst("userId")!.Value);
            return await _context.ChecklistItems.Where(t => t.UserId == userId).ToListAsync(cancellationToken);
        }
    }
}
