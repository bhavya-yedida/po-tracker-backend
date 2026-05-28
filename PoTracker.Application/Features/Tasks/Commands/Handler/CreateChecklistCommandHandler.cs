using MediatR;
using Microsoft.AspNetCore.Http;
using PoTracker.Domain.Entities;
using PoTracker.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoTracker.Application.Features.Tasks.Commands.Handler
{
    public class CreateChecklistCommandHandler : IRequestHandler<CreateChecklistCommand, ChecklistItem>
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateChecklistCommandHandler(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ChecklistItem> Handle(CreateChecklistCommand request, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(_httpContextAccessor.HttpContext!.User.FindFirst("userId")!.Value);

            var item = new ChecklistItem
            {
                Title = request.Title,
                Date = request.Date,
                UserId = userId,
                IsDone = false
            };

            _context.ChecklistItems.Add(item);
            await _context.SaveChangesAsync(cancellationToken);

            return item;
        }
    }
}
