using MediatR;

namespace EShop.Application.Features.Product.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest<bool>
{
    public int Id { get; set; }
}