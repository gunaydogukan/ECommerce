using FluentValidation;

namespace ECommerce.Business.Cart.Commands.Delete
{
    public class DeleteFromCartCommandValidator : AbstractValidator<DeleteFromCartCommand>
    {
        public DeleteFromCartCommandValidator()
        {
            RuleFor(x => x.CartId)
                .GreaterThan(0)
                .WithMessage("CartId 0’dan büyük olmalıdır.");
        }
    }
}