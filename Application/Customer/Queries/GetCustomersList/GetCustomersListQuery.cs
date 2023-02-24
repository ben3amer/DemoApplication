using MediatR;
using Application.Repositories;

namespace Application.Customer.Queries.GetCustomersList;
public class GetCustomersListQuery : IRequest<GetCustomersListVm>
{
    public class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, GetCustomersListVm>
    {
        private readonly ICustomerRepository _repository;
        public GetCustomersListQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetCustomersListVm> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
        {
            var customers = await _repository.GetAllAsync(cancellationToken);

            return new GetCustomersListVm(customers);
        }
    }
}   
