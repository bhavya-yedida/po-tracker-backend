using MediatR;
using Microsoft.EntityFrameworkCore;
using PoTracker.Domain.Entities;
using PoTracker.Infrastructure.Data;

namespace PoTracker.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler
        : IRequestHandler<UpdateTaskCommand, TaskItem?>
    {
        private readonly AppDbContext _context;

        public UpdateTaskCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TaskItem?> Handle(
            UpdateTaskCommand request,
            CancellationToken cancellationToken)
        {
            var task = await _context.Tasks
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (task == null)
                return null;

            task.Title = request.Title;
            task.IsCompleted = request.IsCompleted;

            await _context.SaveChangesAsync(cancellationToken);

            return task;
        }
    }
}