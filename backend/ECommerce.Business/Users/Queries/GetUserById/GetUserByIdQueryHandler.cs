using ECommerce.Business.Users.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Exceptions.Types;
using ECommerce.Entities.Identity;
using MediatR;

namespace ECommerce.Business.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserResponseDto>
    {
        private readonly IUnitOfWork _uow;

        public GetUserByIdQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<UserResponseDto> Handle(GetUserByIdQuery request, CancellationToken ct)
        {
            var userRepo = _uow.Repository<User>();
            var user = await userRepo.GetByIdAsync(request.Id, ct);

            if (user == null)
                throw new BusinessException("Kullanıcı bulunamadı.");

            return new UserResponseDto(
                user.Email,
                user.FirstName,
                user.LastName,
                user.PhoneNumber
            );
        }
    }
}