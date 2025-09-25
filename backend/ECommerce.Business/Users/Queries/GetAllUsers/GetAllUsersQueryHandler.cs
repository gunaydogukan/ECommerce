using ECommerce.Business.Users.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Entities.Identity;
using MediatR;

namespace ECommerce.Business.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IReadOnlyList<UserResponseDto>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllUsersQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IReadOnlyList<UserResponseDto>> Handle(GetAllUsersQuery request, CancellationToken ct)
        {
            var userRepo = _uow.Repository<User>();

            var users = await userRepo.GetAllAsync(ct);

            var dtoList = users.Select(u => new UserResponseDto(
                u.Email,
                u.FirstName,
                u.LastName,
                u.PhoneNumber
            )).ToList();

            return dtoList;
        }
    }
}