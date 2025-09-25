using ECommerce.Business.Users.Dtos;
using ECommerce.Business.Users.Queries.GetAllUsers;
using ECommerce.Business.Users.Queries.GetMe;
using ECommerce.Business.Users.Queries.GetUserById;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Caching;

namespace ECommerce.Business.Users.Commands.Update
{
    public record UpdateUserCommand(int Id) : IBaseCommand<UserResponseDto> , ICacheInvalidation
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public IReadOnlyList<Type> QueryTypes => new[]
        {
            typeof(GetAllUsersQuery),
            typeof(GetMeQuery),
            typeof(GetUserByIdQuery)
        };
    }
}