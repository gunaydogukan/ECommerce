using ECommerce.Business.Users.Queries.GetAllUsers;
using ECommerce.Business.Users.Queries.GetMe;
using ECommerce.Business.Users.Queries.GetUserById;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Caching;

namespace ECommerce.Business.Users.Commands.Delete
{
    public record DeleteUserCommand(int Id) : IBaseCommand<bool>, ICacheInvalidation
    {
        public IReadOnlyList<Type> QueryTypes => new[]
        {
            typeof(GetAllUsersQuery),
            typeof(GetMeQuery),
            typeof(GetUserByIdQuery)
        };
    }
}