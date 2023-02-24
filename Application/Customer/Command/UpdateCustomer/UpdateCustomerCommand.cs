using Application.Common.Exceptions;
using Application.Repositories;
using MediatR;

namespace Application.Customer.Command.UpdateCustomer;
public class UpdateCustomerCommand : IRequest
{
    public UpdateCustomerCommand(int id, string firstName, string lastName, string phone)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
    }
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly ICustomerRepository _repository;
        public UpdateCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }
            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.Phone = request.Phone;
            
            await _repository.UpdateAsync(entity,cancellationToken);

            return Unit.Value;
        }
    }
}
