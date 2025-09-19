using FluentValidation;

namespace ECommerce.Business.Cart.Commands.Update
{
    public class UpdateCartCommandValidator : AbstractValidator<UpdateCartCommand>
    {
        public UpdateCartCommandValidator()
        {
            RuleFor(x => x.CartId)
                .GreaterThan(0).WithMessage("Geçerli bir sepet Id belirtilmelidir.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Adet 0'dan büyük olmalıdır.");
        }
    }
}