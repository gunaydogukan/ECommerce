using ECommerce.Business.Users.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Exceptions.Types;
using ECommerce.Core.Helpers.Security;
using ECommerce.Entities.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Business.Users.Commands.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserResponseDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserAccessor _userAccessor;

        public UpdateUserCommandHandler(IUnitOfWork uow, IUserAccessor userAccessor)
        {
            _uow = uow;
            _userAccessor = userAccessor;
        }

        public async Task<UserResponseDto> Handle(UpdateUserCommand request, CancellationToken ct)
        {
            var userId = _userAccessor.GetUserId();
            var userRepo = _uow.Repository<User>();
            request.Id = userId;

            var user = await userRepo.Query()
                .FirstOrDefaultAsync(u => u.Id == userId, ct);

            if (user == null)
                throw new BusinessException("Kullanıcı bulunamadı.");

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.PhoneNumber = request.PhoneNumber;

            await userRepo.UpdateAsync(user, ct);

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