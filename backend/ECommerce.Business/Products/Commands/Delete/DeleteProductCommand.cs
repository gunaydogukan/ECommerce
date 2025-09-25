using ECommerce.Business.Products.Queries.GetAllProducts;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Caching;

namespace ECommerce.Business.Products.Commands.Delete
{
    public record DeleteProductCommand(int Id) : IBaseCommand<bool> , ICacheInvalidation
    {
        public IReadOnlyList<Type> QueryTypes => new[]
        {
            typeof(GetAllProductsQuery)
        };
    }
}