using AutoMapper;
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
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<UserResponseDto> Handle(RegisterUserCommand request, CancellationToken ct)
        {
            // Email daha önce var mı kontrol et
            var userRepo = _uow.Repository<User>();
            var exists = await userRepo.Query()
                .AnyAsync(u => u.Email == request.Email, ct);

            if (exists)
                throw new BusinessException("Bu email adresi ile zaten kayıt yapılmış.");

            // Şifre hash
            var hashedPassword = PasswordHasher.HashPassword(request.Password);

            // User oluştur
            var user = _mapper.Map<User>(request);
            user.PasswordHash = hashedPassword;

            await userRepo.AddAsync(user, ct);

            // Default rol atama (örneğin RoleId = 1 => "User")
            var userRoleRepo = _uow.Repository<UserRole>();
            var userRole = new UserRole { User = user, RoleId = 1 };
            await userRoleRepo.AddAsync(userRole, ct);

            // Değişiklikleri kaydet
            await _uow.SaveChangesAsync(ct);

            return _mapper.Map<UserResponseDto>(user);
        }
    }
}