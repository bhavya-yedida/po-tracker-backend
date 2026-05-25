using MediatR;
using Microsoft.EntityFrameworkCore;
using PoTracker.Domain.Entities;
using PoTracker.Infrastructure.Data;

namespace PoTracker.Application.Features.Tasks.Queries.Handler
{
    public class GetTasksQueryHandler
        : IRequestHandler<GetTasksQuery, List<TaskItem>>
    {
        private readonly AppDbContext _context;

        public GetTasksQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskItem>> Handle(
            GetTasksQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Tasks
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}