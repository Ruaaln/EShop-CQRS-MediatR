using FluentValidation;
namespace EShop.Application.Features.Category.Commands.CreateCategoy;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ad boş ola bilməz")
            .MaximumLength(100).WithMessage("Ad 100 simvoldan çox ola bilməz");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıqlama 500 simvoldan çox ola bilməz");
    }
}