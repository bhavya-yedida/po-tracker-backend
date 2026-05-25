using MediatR;
using PoTracker.Domain.Entities;

namespace PoTracker.Application.Features.Tasks.Queries
{
    public class GetTasksQuery : IRequest<List<TaskItem>>
    {
    }
}