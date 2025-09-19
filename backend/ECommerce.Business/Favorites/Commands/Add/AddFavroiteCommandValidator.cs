using FluentValidation;

namespace ECommerce.Business.Favorites.Commands.Add
{
    public class AddFavroiteCommandValidator : AbstractValidator<AddFavroiteCommand>
    {
        public AddFavroiteCommandValidator()
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Geçerli bir ürün seçilmelidir.");
        }
    }
}