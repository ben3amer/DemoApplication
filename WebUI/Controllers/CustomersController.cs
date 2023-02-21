using Application.Customer.Command.CreateCustomer;
using Application.Customer.Command.DeleteCustomer;
using Application.Customer.Command.UpdateCustomer;
using Application.Customer.Queries.GetCustomersList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task Create([FromBody] CreateCustomerCommand createCustomerCommand)
    {
        await _mediator.Send(createCustomerCommand);
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetCustomersListVm>> GetAll()
    {
        var vm = await _mediator.Send(new GetCustomersListQuery());

        return Ok(vm);
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update([FromBody] UpdateCustomerCommand updateCustomerCommand)
    {
        await _mediator.Send(updateCustomerCommand);
        return NoContent();
    }
    
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete([FromBody] DeleteCustomerCommand deleteCustomerCommand)
    {
        await _mediator.Send(deleteCustomerCommand);
        return NoContent();
    }


}
