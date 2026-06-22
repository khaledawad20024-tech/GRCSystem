using GRC.Application.DTOs;
using GRC.Domain.Entities;
using GRC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GRC.Application.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly GrcDbContext _context;

        public AuthService(GrcDbContext context)
        {
            _context = context;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var user = await _context.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(x =>
                    x.UserName == request.Username &&
                    x.IsActive);

            if (user == null)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = "Invalid username or password"
                };
            }

            // Temporary password check
            if (user.PasswordHash != request.Password)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = "Invalid username or password"
                };
            }

            return new LoginResponse
            {
                Success = true,
                Message = "Login successful",
                AccessToken = "TEMP_TOKEN",
                RefreshToken = "TEMP_REFRESH_TOKEN",
                User = new UserDto
                {
                    Id = user.Id,
                    Username = user.UserName,
                    FullName = user.FullName,
                    Email = user.Email,
                    IsActive = user.IsActive,
                    Roles = user.UserRoles
                        .Select(r => r.Role.Name)
                        .ToList()
                }
            };
        }
    }
}