using MediatR;
using PoTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoTracker.Application.Features.Tasks.Queries
{
    public class GetChecklistQuery : IRequest<List<ChecklistItem>>
    {
    }
}
