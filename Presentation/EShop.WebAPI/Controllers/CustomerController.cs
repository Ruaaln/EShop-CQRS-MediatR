using EShop.Application.Features.Customer.Commands.CreateCustomer;
using EShop.Application.Features.Customer.Commands.UpdateCustomer;
using EShop.Application.Features.Customer.Commands.DeleteCustomer;
using EShop.Application.Features.Customer.Queries.GetAllCustomers;
using EShop.Application.Features.Customer.Queries.GetCustomerById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllCustomersQuery());
        return Ok(result);
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetCustomerByIdQuery { Id = id });
        if (result is null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost("AddCustomer")]
    public async Task<IActionResult> Add([FromBody] CreateCustomerCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var id = await _mediator.Send(command);
        return StatusCode(201, id);
    }

    [HttpPut("Update/{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCustomerCommand command)
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
        var result = await _mediator.Send(new DeleteCustomerCommand { Id = id });
        if (!result)
            return NotFound();
        return StatusCode(204);
    }
}