using Application.Common.Exceptions;
using Application.Repositories;
using MediatR;

namespace Application.Customer.Command.DeleteCustomer;
public class DeleteCustomerCommand : IRequest
{
    public int Id { get; set; }
    public DeleteCustomerCommand(int id)
    {
        Id = id;
    }
}
public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
{
    private readonly ICustomerRepository _repository;
    public DeleteCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }
    public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);
        if (entity == null)
        {
            throw new NotFoundException(nameof(Customer), request.Id);
        }
        await  _repository.DeleteAsync(entity,cancellationToken);
        return Unit.Value;
    }
}