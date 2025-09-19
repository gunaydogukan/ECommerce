using FluentValidation;

namespace ECommerce.Business.Favorites.Commands.Delete
{
    public class DeleteFavoriteCommandValidator : AbstractValidator<DeleteFavoriteCommand>
    {
        public DeleteFavoriteCommandValidator()
        {
            /*RuleFor(x => x.UserId)
                .GreaterThan(0)
                .WithMessage("Kullanıcı Id 0’dan büyük olmalıdır."); */

            RuleForEach(x => x.ProductIds)
                .GreaterThan(0)
                .WithMessage("Ürün Id 0’dan büyük olmalıdır.");
        }
    }
}