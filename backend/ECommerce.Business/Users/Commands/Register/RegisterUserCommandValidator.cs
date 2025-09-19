using FluentValidation;

namespace ECommerce.Business.Users.Commands.Register
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir email giriniz.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ad boş olamaz.")
                .MaximumLength(100).WithMessage("Ad 100 karakterden uzun olamaz.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyad boş olamaz.")
                .MaximumLength(100).WithMessage("Soyad 100 karakterden uzun olamaz.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre boş olamaz.")
                .MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş olamaz.")
                .MaximumLength(20).WithMessage("Telefon numarası 20 karakterden uzun olamaz.");
        }
    }
}