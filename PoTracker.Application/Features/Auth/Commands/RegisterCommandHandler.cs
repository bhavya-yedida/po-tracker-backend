using MediatR;
using PoTracker.Infrastructure.Data;
using PoTracker.Infrastructure.Services;
using PoTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PoTracker.Application.Features.Auth.Commands
{
    public class RegisterCommandHandler
        : IRequestHandler<RegisterCommand, AuthResponse>
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwtService;

        public RegisterCommandHandler(
            AppDbContext context,
            JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<AuthResponse> Handle(
            RegisterCommand request,
            CancellationToken cancellationToken)
        {
            var exists = await _context.Users
                .AnyAsync(x => x.Email == request.Email);

            if (exists)
                throw new Exception("Email already exists");

            var user = new User
            {
                Id = Guid.NewGuid(),
                FullName = request.FullName,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = "User",
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync(cancellationToken);

            return new AuthResponse
            {
                Token = _jwtService.GenerateToken(user),
                FullName = user.FullName,
                Email = user.Email
            };
        }
    }
}
