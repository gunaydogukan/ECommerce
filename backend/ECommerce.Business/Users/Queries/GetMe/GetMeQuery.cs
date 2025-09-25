using ECommerce.Business.Users.Dtos;
using ECommerce.Core.Caching;

namespace ECommerce.Business.Users.Queries.GetMe
{
    public record GetMeQuery : IUserSpecificCacheableQuery<UserResponseDto>
    {
        
    }
}