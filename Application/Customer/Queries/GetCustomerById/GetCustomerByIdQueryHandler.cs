using Application.Common.Exceptions;
using Application.Repositories;
using MediatR;

namespace Application.Customer.Queries.GetCustomerById;
public class GetCustomerDetailQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDetailVm>
{
    private readonly ICustomerRepository _repository;
    public GetCustomerDetailQueryHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }
    public async Task<CustomerDetailVm> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);
        if (entity == null)
        {
            throw new NotFoundException(nameof(Customer), request.Id);
        }
        return new CustomerDetailVm(entity);
    }
}
