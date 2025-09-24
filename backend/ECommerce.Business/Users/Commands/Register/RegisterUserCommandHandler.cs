using ECommerce.Business.Users.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Exceptions.Types;
using ECommerce.Core.Helpers.Security;
using ECommerce.Entities.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace ECommerce.Business.Users.Commands.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserResponseDto>
    {
        private readonly IUnitOfWork _uow;

        public RegisterUserCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<UserResponseDto> Handle(RegisterUserCommand request, CancellationToken ct)
        {
            var userRepo = _uow.Repository<User>();
            var exists = await userRepo.Query()
                .AnyAsync(u => u.Email == request.Email, ct);

            if (exists)
                throw new BusinessException("Bu email adresi ile zaten kayıt yapılmış.");

            // Şifre hash
            var hashedPassword = PasswordHasher.HashPassword(request.Password);

            var user = new User
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PasswordHash = hashedPassword,
                PhoneNumber = request.PhoneNumber
            };

            await userRepo.AddAsync(user, ct);

            var userRoleRepo = _uow.Repository<UserRole>();
            var userRole = new UserRole { User = user, RoleId = 1 };
            
            await userRoleRepo.AddAsync(userRole, ct);


            return ToResponseDto(user);
        }
        
        private static UserResponseDto ToResponseDto(User user)
        {
            return new UserResponseDto(
                user.Email,
                user.FirstName,
                user.LastName,
                user.PhoneNumber
            );
        }
    }
}