using ECommerce.Entities.Identity;

namespace ECommerce.Core.Abstractions
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user, string roleName);
    }
}