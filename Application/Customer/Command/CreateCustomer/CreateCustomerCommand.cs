using Application.Common;
using Application.Repositories;
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
    private readonly ICustomerRepository _repository;

    public CreateCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
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
        await _repository.AddAsync(customer,cancellationToken);
        
        return Unit.Value;
    }
}