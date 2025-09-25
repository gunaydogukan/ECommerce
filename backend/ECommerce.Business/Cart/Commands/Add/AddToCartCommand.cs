using ECommerce.Business.Cart.Dtos;
using ECommerce.Business.Cart.Queries.GetMyCart;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Caching;

namespace ECommerce.Business.Cart.Commands.Add
{
    public record AddToCartCommand : IBaseCommand<CartResponseDto>, ICacheInvalidation
    {
        //internal int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public IReadOnlyList<Type> QueryTypes => new[]
        {
            typeof(GetMyCartQuery)
        };
    }
}