namespace ECommerce.Core.Caching;

public interface ICacheInvalidation
{
    IReadOnlyList<Type> QueryTypes { get; }
}