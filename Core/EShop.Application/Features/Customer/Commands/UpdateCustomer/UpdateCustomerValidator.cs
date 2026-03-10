using FluentValidation;

namespace EShop.Application.Features.Customer.Commands.UpdateCustomer;

public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Düzgün Id daxil edin");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Ad boş ola bilməz")
            .MaximumLength(50).WithMessage("Ad 50 simvoldan çox ola bilməz");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Soyad boş ola bilməz")
            .MaximumLength(50).WithMessage("Soyad 50 simvoldan çox ola bilməz");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Telefon boş ola bilməz")
            .MaximumLength(20).WithMessage("Telefon 20 simvoldan çox ola bilməz");
    }
}