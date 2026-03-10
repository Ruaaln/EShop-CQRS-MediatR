using EShop.Application.DTOs.Product;
using MediatR;

namespace EShop.Application.Features.Product.Queries.GetProductById;

public class GetProductByIdQuery : IRequest<ProductDto>
{
    public int Id { get; set; }
}