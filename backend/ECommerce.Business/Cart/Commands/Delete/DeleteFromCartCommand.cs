using ECommerce.Core.Abstractions;

namespace ECommerce.Business.Cart.Commands.Delete
{
    // Handler dönüş tipi sadece bool olacak
    public class DeleteFromCartCommand : IBaseCommand<bool>
    {
        public int CartId { get; set; }

        public DeleteFromCartCommand(int cartId)
        {
            CartId = cartId;
        }
    }
}