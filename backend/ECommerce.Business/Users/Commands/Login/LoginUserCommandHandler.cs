using ECommerce.Core.Helpers.Security;
using ECommerce.Business.Users.Dtos;
using MediatR;
using ECommerce.Core.Exceptions.Types;
using ECommerce.Core.Abstractions;
using ECommerce.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Business.Users.Commands.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResponseDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IJwtTokenService _jwtService;
        private readonly CookieHelper _cookieHelper;

        public LoginUserCommandHandler(IUnitOfWork uow, IJwtTokenService jwtService, CookieHelper cookieHelper)
        {
            _uow = uow;
            _jwtService = jwtService;
            _cookieHelper = cookieHelper;
        }

        public async Task<LoginResponseDto> Handle(LoginUserCommand request, CancellationToken ct)
        {
            var userRepo = _uow.Repository<User>();

            var user = await userRepo.Query()
                .Include(u => u.UserRole)
                .ThenInclude(ur => ur.Role)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == request.Email, ct);

            if (user == null)
                throw new BusinessException("Geçersiz email veya şifre.");

            var valid = PasswordHasher.VerifyPassword(request.Password, user.PasswordHash);
            if (!valid)
                throw new BusinessException("Geçersiz email veya şifre.");

            var roleName = user.UserRole?.Role?.Name ?? "User";

            var token = _jwtService.GenerateToken(user, roleName);
            _cookieHelper.SetTokenCookie(token, DateTimeOffset.UtcNow.AddMinutes(60));

            return new LoginResponseDto(
                user.Id,
                user.Email,
                $"{user.FirstName} {user.LastName}"
            );
        }
    }
}