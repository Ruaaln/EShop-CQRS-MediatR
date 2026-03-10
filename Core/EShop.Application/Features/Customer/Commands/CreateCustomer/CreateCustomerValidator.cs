using FluentValidation;

namespace EShop.Application.Features.Customer.Commands.CreateCustomer;

public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ad boş ola bilməz")
            .MaximumLength(50).WithMessage("Ad 50 simvoldan çox ola bilməz");

        RuleFor(x => x.Surname)
            .NotEmpty().WithMessage("Soyad boş ola bilməz")
            .MaximumLength(50).WithMessage("Soyad 50 simvoldan çox ola bilməz");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email boş ola bilməz")
            .EmailAddress().WithMessage("Düzgün email formatı daxil edin");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifrə boş ola bilməz")
            .MinimumLength(6).WithMessage("Şifrə ən az 6 simvol olmalıdır");

    }
}