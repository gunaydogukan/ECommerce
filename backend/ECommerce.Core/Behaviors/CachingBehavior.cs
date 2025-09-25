using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using ECommerce.Core.Caching;
using ECommerce.Core.Helpers.Security;

namespace ECommerce.Core.Behaviors
{
    public class CachingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICacheableQuery<TResponse>
    {
        private readonly IDistributedCache _cache;
        private readonly IUserAccessor _userAccessor;

        public CachingBehavior(IDistributedCache cache,IUserAccessor userAccessor)
        {
            _cache = cache;
            _userAccessor = userAccessor;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            try
            {
                var cacheKey = GenerateCacheKey(request);

                var cachedData = await _cache.GetStringAsync(cacheKey, cancellationToken);
                if (!string.IsNullOrWhiteSpace(cachedData))
                {
                    return JsonSerializer.Deserialize<TResponse>(cachedData)!;
                }

                var response = await next();

                await SetCache(cacheKey, response, cancellationToken);

                return response;
            }
            catch
            {
                return await next();
            }
        }

        private string GenerateCacheKey(TRequest request)
        {
            var requestName = typeof(TRequest).Name;

            var props = request.GetType()
                .GetProperties()
                .Where(p => p.CanRead)
                .Select(p => $"{p.Name}:{p.GetValue(request)}")
                .ToArray();

            var parts = new List<string> { requestName };

            if (request is IUserSpecificCacheableQuery<TResponse>)
            {
                var userId = _userAccessor.GetUserId();
                parts.Add($"UserId:{userId}");
            }

            if (props.Length > 0)
                parts.Add(string.Join("-", props));

            return string.Join("-", parts);
        }

        private async Task SetCache(string key, TResponse response, CancellationToken ct)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(20) 
            };

            var data = JsonSerializer.Serialize(response);
            await _cache.SetStringAsync(key, data, options, ct);
        }
    }
}
