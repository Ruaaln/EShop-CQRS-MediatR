using FluentValidation;

namespace EShop.Application.Features.Product.Commands.CreateProduct;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Məhsul adı boş ola bilməz")
            .MaximumLength(200).WithMessage("Məhsul adı 200 simvoldan çox ola bilməz");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Qiymət 0-dan böyük olmalıdır");

        RuleFor(x => x.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("Stok mənfi ola bilməz");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("Düzgün kateqoriya seçin");
    }
}