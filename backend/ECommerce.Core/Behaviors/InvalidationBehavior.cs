using ECommerce.Core.Abstractions;
using ECommerce.Core.Caching;
using ECommerce.Core.Helpers;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace ECommerce.Core.Behaviors;

public class InvalidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseCommand<TResponse>, ICacheInvalidation
{
    private readonly IDistributedCache _cache;
    private readonly IUserAccessor _userAccessor;

    public InvalidationBehavior(IDistributedCache cache, IUserAccessor userAccessor)
    {
        _cache = cache;
        _userAccessor = userAccessor;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken ct)
    {
        var response = await next();

        foreach (var queryType in request.QueryTypes ?? Enumerable.Empty<Type>())
        {
            try
            {
                var key = CacheKeyHelper.GenerateCacheKey(queryType, _userAccessor);
                if (!string.IsNullOrWhiteSpace(key))
                {
                    await _cache.RemoveAsync(key, ct);
                    Console.WriteLine($"Cache invalidated: {key}");
                }
            }
            catch
            {
                Console.WriteLine($"Redis'e bağlanılamadı");
            }
        }

        return response;
    }
}