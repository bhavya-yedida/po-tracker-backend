using MediatR;
using Microsoft.EntityFrameworkCore;
using PoTracker.Infrastructure.Data;
using PoTracker.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoTracker.Application.Features.Auth.Commands
{
    public class LoginCommandHandler
        : IRequestHandler<LoginCommand, AuthResponse>
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwtService;

        public LoginCommandHandler(
            AppDbContext context,
            JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<AuthResponse> Handle(
            LoginCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == request.Email);

            if (user == null)
                throw new Exception("Invalid credentials");

            var valid = BCrypt.Net.BCrypt.Verify(
                request.Password,
                user.PasswordHash
            );

            if (!valid)
                throw new Exception("Invalid credentials");

            return new AuthResponse
            {
                Token = _jwtService.GenerateToken(user),
                FullName = user.FullName,
                Email = user.Email
            };
        }
    }
}
