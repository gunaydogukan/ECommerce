using ECommerce.Core.Abstractions;

namespace ECommerce.Core.Caching;

public interface ICacheableQuery<TResponse> : IBaseQuery<TResponse>
{
    string CacheKey { get; }
    TimeSpan? Expiration { get; }
}