using ECommerce.Business.Users.Dtos;
using ECommerce.Core.Abstractions;
using MediatR;

namespace ECommerce.Business.Users.Commands.Register
{
    public class RegisterUserCommand : IBaseCommand<UserResponseDto>
    {
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}