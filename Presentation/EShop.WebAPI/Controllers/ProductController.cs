using EShop.Application.Features.Product.Commands.CreateProduct;
using EShop.Application.Features.Product.Commands.DeleteProduct;
using EShop.Application.Features.Product.Commands.UpdateProduct;
using EShop.Application.Features.Product.Queries.GetAllProducts;
using EShop.Application.Features.Product.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllProductsQuery());
        return Ok(result);
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetProductByIdQuery { Id = id });
        if (result is null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost("AddProduct")]
    public async Task<IActionResult> Add([FromBody] CreateProductCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var id = await _mediator.Send(command);
        return StatusCode(201, id);
    }

    [HttpPut("Update/{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        if (!result)
            return NotFound();
        return StatusCode(204);
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var result = await _mediator.Send(new DeleteProductCommand { Id = id });
        if (!result)
            return NotFound();
        return StatusCode(204);
    }
}