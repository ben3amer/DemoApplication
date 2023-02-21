using Application.Common;
using MediatR;
using CustomerModel = Domain.Entities.Customer.Customer;

namespace Application.Customer.Command.CreateCustomer;
public class CreateCustomerCommand : IRequest
{
    public CreateCustomerCommand(int id, string lastName, string firstName, string phone)
    {
        Id = id;
        LastName = lastName;
        FirstName = firstName;
        Phone = phone;
    }
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
}

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
{
    private readonly IDemoDbContext _dbContext;
    private readonly IMediator _mediator;

    public CreateCustomerCommandHandler(IMediator mediator, IDemoDbContext dbContext)
    {
        _mediator = mediator;
        _dbContext = dbContext;
    }
    public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new CustomerModel
        (
            request.Id,
            request.FirstName,
            request.LastName,
            request.Phone
        );
        _dbContext.Customers.Add(customer);
        await _dbContext.SaveChangesAsync(cancellationToken);
        await _mediator.Publish(new CustomerCreated
        {
            Id = customer.Id
        }, cancellationToken);
        
        return Unit.Value;
    }
}