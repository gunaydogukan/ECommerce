using FluentValidation;

namespace ECommerce.Business.Cart.Commands.Add
{
    public class AddToCartCommandValidator : AbstractValidator<AddToCartCommand>
    {
        public AddToCartCommandValidator()
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Geçerli bir ürün seçilmelidir.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Adet 0'dan büyük olmalıdır.");
        }
    }
}