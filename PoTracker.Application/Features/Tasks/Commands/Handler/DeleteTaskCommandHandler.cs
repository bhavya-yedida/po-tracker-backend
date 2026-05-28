using MediatR;
using Microsoft.EntityFrameworkCore;
using PoTracker.Infrastructure.Data;

namespace PoTracker.Application.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly AppDbContext _context;

        public DeleteTaskCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.FindAsync(request.Id);

            if (task == null) return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}