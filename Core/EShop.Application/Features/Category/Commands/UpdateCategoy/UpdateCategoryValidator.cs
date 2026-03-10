using FluentValidation;

namespace EShop.Application.Features.Category.Commands.UpdateCategoy;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Düzgün Id daxil edin");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ad boş ola bilməz")
            .MaximumLength(100).WithMessage("Ad 100 simvoldan çox ola bilməz");
    }
}