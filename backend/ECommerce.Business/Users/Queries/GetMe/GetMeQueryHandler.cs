using AutoMapper;
using ECommerce.Business.Users.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Exceptions.Types;
using ECommerce.Core.Helpers.Security;
using ECommerce.Entities.Identity;
using MediatR;

namespace ECommerce.Business.Users.Queries.GetMe
{
    public class GetMeQueryHandler : IRequestHandler<GetMeQuery, UserResponseDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserAccessor _userAccessor;
        private readonly IMapper _mapper;

        public GetMeQueryHandler(IUnitOfWork uow, IUserAccessor userAccessor, IMapper mapper)
        {
            _uow = uow;
            _userAccessor = userAccessor;
            _mapper = mapper;
        }

        public async Task<UserResponseDto> Handle(GetMeQuery request, CancellationToken ct)
        {
            var userId = _userAccessor.GetUserId();

            var userRepo = _uow.Repository<User>();
            var user = await userRepo.GetByIdAsync(userId, ct);

            if (user == null)
                throw new BusinessException("Kullanıcı bulunamadı.");

            return _mapper.Map<UserResponseDto>(user);
        }
    }
}