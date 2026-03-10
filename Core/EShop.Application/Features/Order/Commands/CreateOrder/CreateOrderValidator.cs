using FluentValidation;

namespace EShop.Application.Features.Order.Commands.CreateOrder;

public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderValidator()
    {
        RuleFor(x => x.CustomerId)
            .GreaterThan(0).WithMessage("Düzgün müştəri seçin");


        RuleFor(x => x.Items)
            .NotEmpty().WithMessage("Sifariş ən az 1 məhsul içerməlidir");

        RuleForEach(x => x.Items).ChildRules(item =>
        {
            item.RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Düzgün məhsul seçin");

            item.RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Miqdar 0-dan böyük olmalıdır");
        });
    }
}