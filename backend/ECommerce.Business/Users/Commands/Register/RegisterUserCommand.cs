using ECommerce.Business.Users.Dtos;
using ECommerce.Core.Abstractions;

namespace ECommerce.Business.Users.Commands.Register
{
    public record RegisterUserCommand(
        string Email,
        string FirstName,
        string LastName,
        string Password,
        string PhoneNumber
    ) : IBaseCommand<UserResponseDto>;
}