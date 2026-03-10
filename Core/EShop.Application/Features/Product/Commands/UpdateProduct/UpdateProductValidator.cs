using FluentValidation;

namespace EShop.Application.Features.Product.Commands.UpdateProduct;

public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Düzgün Id daxil edin");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Məhsul adı boş ola bilməz")
            .MaximumLength(200).WithMessage("Məhsul adı 200 simvoldan çox ola bilməz");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Qiymət 0-dan böyük olmalıdır");

        RuleFor(x => x.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("Stok mənfi ola bilməz");
    }
}