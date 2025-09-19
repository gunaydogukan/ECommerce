using ECommerce.Core.Abstractions;
using ECommerce.Core.Caching;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace ECommerce.Core.Behaviors;

public class InvalidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseCommand<TResponse>, ICacheInvalidation
{
    private readonly IDistributedCache? _cache;

    public InvalidationBehavior(IDistributedCache? cache)
    {
        _cache = cache;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken ct)
    {
        var response = await next();

        foreach (var key in request.CacheKeys ?? Enumerable.Empty<string>())
        {
            try
            {
                await _cache.RemoveAsync(key, ct);
                Console.WriteLine($"Anahtar silindi: {key}");
            }
            catch
            {
                Console.WriteLine($"Redise bağlanılamadı");
            }
        }

        return response;
    }
}