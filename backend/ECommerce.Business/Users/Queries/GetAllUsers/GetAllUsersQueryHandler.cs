using AutoMapper;
using ECommerce.Business.Users.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Entities.Identity;
using MediatR;

namespace ECommerce.Business.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IReadOnlyList<UserResponseDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<UserResponseDto>> Handle(GetAllUsersQuery request, CancellationToken ct)
        {
            var userRepo = _uow.Repository<User>();

            var users = await userRepo.GetAllAsync(ct);


            return _mapper.Map<IReadOnlyList<UserResponseDto>>(users);
        }
    }
}