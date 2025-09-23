using Microsoft.AspNetCore.Http;

namespace ECommerce.Core.Helpers.Security;

public class CookieHelper
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CookieHelper(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void SetTokenCookie(string token, DateTimeOffset expires)
    {
        var context = _httpContextAccessor.HttpContext;
        context?.Response.Cookies.Append("accessToken", token, new CookieOptions
        {
            HttpOnly = true,
            Secure = false,
            SameSite = SameSiteMode.Lax,
            Expires = expires,
            IsEssential = true
        });
    }
}