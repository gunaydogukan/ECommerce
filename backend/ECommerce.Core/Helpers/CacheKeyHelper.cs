using ECommerce.Core.Abstractions;
using ECommerce.Core.Caching;

namespace ECommerce.Core.Helpers;

public class CacheKeyHelper
{
    public static string GenerateCacheKey(Type request, IUserAccessor userAccessor)
    {
        var requestName = request.Name;

        var props = request
            .GetProperties()
            .Where(p => p.CanRead)
            .Select(p => $"{p.Name}:{p.GetValue(request)}")
            .ToArray();

        var parts = new List<string> { requestName };

        var isUserSpecific = request.GetInterfaces().Any(i =>
            i.IsGenericType &&
            i.GetGenericTypeDefinition() == typeof(IUserSpecificCacheableQuery<>));

        if (isUserSpecific)
        {
            var userId = userAccessor.GetUserId();
            parts.Add($"UserId:{userId}");
        }

        if (props.Length > 0)
            parts.Add(string.Join("-", props));

        return string.Join("-", parts);
    }
}
