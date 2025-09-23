using ECommerce.Business.Cart.Dtos;
using ECommerce.Core.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Business.Cart.Commands.Update
{
    public record UpdateCartCommand([property: FromRoute] int CartId, int Quantity) : IBaseCommand<CartResponseDto>;
}