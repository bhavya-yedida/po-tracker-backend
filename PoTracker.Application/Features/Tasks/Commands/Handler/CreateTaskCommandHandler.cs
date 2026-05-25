using MediatR;
using PoTracker.Domain.Entities;
using PoTracker.Infrastructure.Data;

namespace PoTracker.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandHandler
        : IRequestHandler<CreateTaskCommand, TaskItem>
    {
        private readonly AppDbContext _context;

        public CreateTaskCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TaskItem> Handle(
            CreateTaskCommand request,
            CancellationToken cancellationToken)
        {
            var task = new TaskItem
            {
                Title = request.Title,
                IsCompleted = false
            };

            _context.Tasks.Add(task);

            await _context.SaveChangesAsync(cancellationToken);

            return task;
        }
    }
}