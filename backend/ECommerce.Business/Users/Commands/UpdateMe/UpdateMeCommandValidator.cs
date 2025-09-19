using FluentValidation;

namespace ECommerce.Business.Users.Commands.UpdateMe;

public class UpdateMeCommandValidator : AbstractValidator<UpdateMeCommand>
{
    public UpdateMeCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Ad boş olamaz.")
            .MinimumLength(2).WithMessage("Ad en az 2 karakter olmalı.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Soyad boş olamaz.")
            .MinimumLength(2).WithMessage("Soyad en az 2 karakter olmalı.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Telefon numarası boş olamaz.")
            .Matches(@"^\d{10,15}$").WithMessage("Telefon numarası 10-15 haneli olmalı.");

        RuleFor(x => x.CurrentPassword)
            .NotEmpty().WithMessage("Eski şifre boş olamaz.")
            .When(x => !string.IsNullOrWhiteSpace(x.NewPassword));

        // Eğer Eski Şifre girildiyse Yeni Şifre zorunlu
        RuleFor(x => x.NewPassword)
            .NotEmpty().WithMessage("Yeni şifre boş olamaz.")
            .MinimumLength(6).WithMessage("Yeni şifre en az 6 karakter olmalı.")
            .When(x => !string.IsNullOrWhiteSpace(x.CurrentPassword));
    }
}
