using EShop.Application.Features.Order.Commands.CreateOrder;
using EShop.Application.Features.Order.Commands.UpdateOrderStatus;
using EShop.Application.Features.Order.Commands.CancelOrder;
using EShop.Application.Features.Order.Queries.GetAllOrders;
using EShop.Application.Features.Order.Queries.GetOrderById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllOrdersQuery());
        return Ok(result);
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetOrderByIdQuery { Id = id });
        if (result is null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost("CreateOrder")]
    public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var id = await _mediator.Send(command);
        return StatusCode(201, id);
    }

    [HttpPatch("UpdateStatus/{id}")]
    public async Task<IActionResult> UpdateStatus([FromRoute] int id, [FromBody] UpdateOrderStatusCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        if (!result)
            return NotFound();
        return StatusCode(204);
    }

    [HttpPatch("Cancel/{id}")]
    public async Task<IActionResult> Cancel([FromRoute] int id)
    {
        var result = await _mediator.Send(new CancelOrderCommand { Id = id });
        if (!result)
            return NotFound();
        return StatusCode(204);
    }
}