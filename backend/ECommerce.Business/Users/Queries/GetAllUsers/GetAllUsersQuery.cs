using ECommerce.Business.Users.Dtos;
using ECommerce.Core.Caching;

namespace ECommerce.Business.Users.Queries.GetAllUsers
{
    public record GetAllUsersQuery : ICacheableQuery<IReadOnlyList<UserResponseDto>>
    {
        //public string CacheKey => "all-users";

        //public TimeSpan? Expiration => TimeSpan.FromMinutes(30);
    }
}