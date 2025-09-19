namespace ECommerce.Core.Caching;

public interface ICacheInvalidation
{
    IReadOnlyList<string> CacheKeys {get; }
}