using ECommerce.Business.OrderItem.Dtos;
using FluentValidation;

namespace ECommerce.Business.Order.Commands.Add
{
    public class AddOrderCommandValidator : AbstractValidator<AddOrderCommand>
    {
        public AddOrderCommandValidator()
        {
            // Eğer Items gönderilmişse, boş olamaz
            RuleFor(x => x.Items)
                .NotNull().WithMessage("Sipariş öğeleri boş olamaz.")
                .Must(items => items.Count > 0).WithMessage("En az bir sipariş öğesi olmalıdır.")
                .When(x => x.Items != null && x.Items.Count > 0);

            // Items içindeki her bir ürün için kurallar
            RuleForEach(x => x.Items).ChildRules(orderItem =>
            {
                orderItem.RuleFor(i => i.ProductId)
                    .GreaterThan(0).WithMessage("Geçerli bir ürün seçilmelidir.");

                orderItem.RuleFor(i => i.Quantity)
                    .GreaterThan(0).WithMessage("Adet 0'dan büyük olmalıdır.");
            });
        }
    }
}