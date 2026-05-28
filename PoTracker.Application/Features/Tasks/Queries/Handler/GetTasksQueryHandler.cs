using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PoTracker.Domain.Entities;
using PoTracker.Infrastructure.Data;

namespace PoTracker.Application.Features.Tasks.Queries.Handler
{
    public class GetTasksQueryHandler
        : IRequestHandler<GetTasksQuery, List<TaskItem>>
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetTasksQueryHandler(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<TaskItem>> Handle(
            GetTasksQuery request,
            CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(_httpContextAccessor.HttpContext!.User.FindFirst("userId")!.Value);

            return await _context.Tasks
                .Where(t => t.UserId == userId).ToListAsync(cancellationToken);
        }
    }
}