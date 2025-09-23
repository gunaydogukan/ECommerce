using ECommerce.Business.Users.Dtos;
using ECommerce.Core.Abstractions;

namespace ECommerce.Business.Users.Commands.Login
{
    public record LoginUserCommand(string Email, string Password) : IBaseCommand<LoginResponseDto>;
}