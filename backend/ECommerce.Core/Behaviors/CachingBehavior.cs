using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using ECommerce.Core.Caching;

namespace ECommerce.Core.Behaviors
{
    public class CachingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IDistributedCache _cache;

        public CachingBehavior(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (request is not ICacheableQuery<TResponse> cacheable)
                return await next();

            try
            {
                // rediste var mı kontrol 
                var cachedData = await _cache.GetStringAsync(cacheable.CacheKey, cancellationToken);
                if (!string.IsNullOrEmpty(cachedData))
                {
                    return JsonSerializer.Deserialize<TResponse>(cachedData)!;
                }

                // yoksa handler çalıştır
                var response = await next();

                // redise ekle
                var options = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = cacheable.Expiration ?? TimeSpan.FromMinutes(5)
                };

                await _cache.SetStringAsync(
                    cacheable.CacheKey,
                    JsonSerializer.Serialize(response),
                    options,
                    cancellationToken
                );

                return response;
            }
            catch (Exception ex)
            {
                return await next(); // redis yoksa db devam
            }
        }
    }
}
