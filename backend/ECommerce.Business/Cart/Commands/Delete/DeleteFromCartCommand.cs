using ECommerce.Business.Cart.Queries.GetMyCart;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Caching;

namespace ECommerce.Business.Cart.Commands.Delete
{
    public record DeleteFromCartCommand(int CartId) : IBaseCommand<bool>, ICacheInvalidation
    {
        public IReadOnlyList<Type> QueryTypes => new[]
        {
            typeof(GetMyCartQuery)
        };
    }
}