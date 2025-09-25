using ECommerce.Business.Cart.Dtos;
using ECommerce.Business.Cart.Queries.GetMyCart;
using ECommerce.Core.Abstractions;
using ECommerce.Core.Caching;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Business.Cart.Commands.Update
{
    public record UpdateCartCommand([property: FromRoute] int CartId, int Quantity)
        : IBaseCommand<CartResponseDto>, ICacheInvalidation
    {
        public IReadOnlyList<Type> QueryTypes => new[]
        {
            typeof(GetMyCartQuery)
        };
    }
}