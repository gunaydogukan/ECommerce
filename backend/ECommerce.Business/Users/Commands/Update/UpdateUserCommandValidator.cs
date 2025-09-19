using FluentValidation;

namespace ECommerce.Business.Users.Commands.Update
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Kullanıcı Id geçerli olmalı.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ad boş olamaz.")
                .MinimumLength(2).WithMessage("Ad en az 2 karakter olmalı.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyad boş olamaz.")
                .MinimumLength(2).WithMessage("Soyad en az 2 karakter olmalı.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş olamaz.")
                .Matches(@"^\d{10,15}$").WithMessage("Telefon numarası 10-15 haneli olmalı.");
        }
    }
}