using EShop.Application.Features.Category.Commands.CreateCategoy;
using EShop.Application.Features.Category.Commands.DeleteCategoy;
using EShop.Application.Features.Category.Commands.UpdateCategoy;
using EShop.Application.Features.Category.Queries.GetAllCategories;
using EShop.Application.Features.Category.Queries.GetCategoryById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;
    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllCategoriesQuery());
        return Ok(result);
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetCategoryByIdQuery { Id = id });
        if (result is null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost("AddCategory")]
    public async Task<IActionResult> Add([FromBody] CreateCategoryCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var id = await _mediator.Send(command);
        return StatusCode(201, id);
    }

    [HttpPut("Update/{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryCommand command)
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
        var result = await _mediator.Send(new DeleteCategoryCommand { Id = id });
        if (!result)
            return NotFound();
        return StatusCode(204);
    }
}