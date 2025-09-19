using ECommerce.Business.Cart.Dtos;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Caching;

namespace ECommerce.Business.Cart.Commands.Add
{
    public class AddToCartCommand : IBaseCommand<CartResponseDto>, ICacheInvalidation
    {
        internal int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public IReadOnlyList<string> CacheKeys => new[]
        {
            $"cart-user-{UserId}"
        };

    }
}