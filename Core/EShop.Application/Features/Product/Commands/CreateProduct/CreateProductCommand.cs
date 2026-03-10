using MediatR;

namespace EShop.Application.Features.Product.Commands.CreateProduct;

public class CreateProductCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public string ImageUrl { get; set; }
}