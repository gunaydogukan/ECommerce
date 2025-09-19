using ECommerce.Business.Users.Dtos;
using ECommerce.Core.Abstractions;
using MediatR;

namespace ECommerce.Business.Users.Commands.Login
{
    public class LoginUserCommand : IBaseCommand<LoginResponseDto>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}