using ECommerce.Entities.Identity;

namespace ECommerce.Core.Helpers.Security
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user, string roleName);
    }
}