using MediatR;
using PoTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoTracker.Application.Features.Tasks.Commands
{
    public class UpdateNoteCommand : IRequest<Note?>
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;

        public string? Tags { get; set; }
    }
}
