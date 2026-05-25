using MediatR;
using PoTracker.Domain.Entities;

namespace PoTracker.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommand : IRequest<TaskItem?>
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }
    }
}