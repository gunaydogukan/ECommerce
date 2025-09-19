using FluentValidation;

namespace ECommerce.Business.Users.Commands.Delete
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Kullanıcı Id 0’dan büyük olmalıdır.");
        }
    }
}