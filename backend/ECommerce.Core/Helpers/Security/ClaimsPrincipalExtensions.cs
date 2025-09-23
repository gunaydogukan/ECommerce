using System.Security.Claims;

namespace ECommerce.Core.Helpers.Security
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(userId))
                throw new Exception("Kullanıcı kimliği bulunamadı.");

            return int.Parse(userId);
        }
    }
}