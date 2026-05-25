using MediatR;
using PoTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoTracker.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<TaskItem>
    {
        public string Title { get; set; } = string.Empty;
    }
}