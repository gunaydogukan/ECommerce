using ECommerce.Core.Abstractions;

namespace ECommerce.Business.Cart.Commands.Delete
{
    public record DeleteFromCartCommand(int CartId) : IBaseCommand<bool>;
}