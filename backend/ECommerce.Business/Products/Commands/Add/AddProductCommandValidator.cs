using FluentValidation;

namespace ECommerce.Business.Products.Commands.Add
{
    public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidator()
        {
            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Kategori seçilmelidir.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ürün adı boş olamaz.")
                .MaximumLength(100).WithMessage("Ürün adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır.");
        }
    }
}