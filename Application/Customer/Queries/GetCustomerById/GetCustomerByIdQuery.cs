using MediatR;

namespace Application.Customer.Queries.GetCustomerById;

public class GetCustomerByIdQuery : IRequest<CustomerDetailVm>
{
    public string Id { get; set; }
}
