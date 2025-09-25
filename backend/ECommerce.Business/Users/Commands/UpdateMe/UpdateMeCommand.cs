using ECommerce.Business.Users.Dtos;
using ECommerce.Business.Users.Queries.GetAllUsers;
using ECommerce.Business.Users.Queries.GetMe;
using ECommerce.Business.Users.Queries.GetUserById;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Caching;

namespace ECommerce.Business.Users.Commands.UpdateMe
{
    public record UpdateMeCommand : IBaseCommand<UserResponseDto>, ICacheInvalidation
    {
        //internal int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public string? CurrentPassword { get; set; }   
        public string? NewPassword { get; set; }

        public IReadOnlyList<Type> QueryTypes => new[]
        {
            typeof(GetAllUsersQuery),
            typeof(GetMeQuery),
            typeof(GetUserByIdQuery)
        };
    }
}