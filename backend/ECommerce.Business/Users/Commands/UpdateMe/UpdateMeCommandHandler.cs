using AutoMapper;
using ECommerce.Business.Users.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Exceptions.Types;
using ECommerce.Core.Helpers.Security;
using MediatR;

namespace ECommerce.Business.Users.Commands.UpdateMe;

public class UpdateMeCommandHandler : IRequestHandler<UpdateMeCommand, UserResponseDto>
{
    private  readonly IUnitOfWork _uow;
    private readonly IUserAccessor _userAccessor;
    private readonly IMapper _mapper;

    public UpdateMeCommandHandler(IUnitOfWork uow, IUserAccessor userAccessor, IMapper mapper)
    {
        _uow = uow;
        _userAccessor = userAccessor;
        _mapper = mapper;
    }

    public async Task<UserResponseDto> Handle(UpdateMeCommand request, CancellationToken ct)
    {
        var userId = _userAccessor.GetUserId();
        var userRepo = _uow.Repository<Entities.Identity.User>();
        request.Id = userId;

        var user = await userRepo.GetByIdAsync(userId, ct);

        if (user == null)
            throw new BusinessException("Kullanıcı Bulunamadı");

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.PhoneNumber = request.PhoneNumber;

        if (!string.IsNullOrEmpty(request.NewPassword) && !string.IsNullOrEmpty(request.CurrentPassword))
        {
            var valid = PasswordHasher.VerifyPassword(request.CurrentPassword, user.PasswordHash);

            if (string.IsNullOrEmpty(request.CurrentPassword) || !valid)
            {
                throw new BusinessException("Şifreler uyuşmuyor");
            }

            user.PasswordHash = PasswordHasher.HashPassword(request.NewPassword);
        }

        await userRepo.UpdateAsync(user, ct);

        return _mapper.Map<UserResponseDto>(user);
    }
}