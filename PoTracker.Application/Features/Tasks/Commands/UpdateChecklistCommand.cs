using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoTracker.Application.Features.Tasks.Commands
{
    public class UpdateChecklistCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public bool IsDone { get; set; }
    }
}
