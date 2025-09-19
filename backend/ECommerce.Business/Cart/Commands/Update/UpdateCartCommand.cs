using ECommerce.Business.Cart.Dtos;
using ECommerce.Core.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Business.Cart.Commands.Update
{
    public class UpdateCartCommand : IBaseCommand<CartResponseDto>
    {
        [FromRoute]
        public int CartId { get; set; }
        public int Quantity { get; set; }
    }
}