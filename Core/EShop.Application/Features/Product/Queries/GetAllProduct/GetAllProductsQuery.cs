using EShop.Application.DTOs.Product;
using MediatR;

namespace EShop.Application.Features.Product.Queries.GetAllProducts;

public class GetAllProductsQuery : IRequest<List<ProductDto>>
{
}