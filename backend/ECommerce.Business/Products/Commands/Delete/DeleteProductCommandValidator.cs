using FluentValidation;

namespace ECommerce.Business.Products.Commands.Delete
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Ürün Id 0’dan büyük olmalıdır.");
        }
    }
}