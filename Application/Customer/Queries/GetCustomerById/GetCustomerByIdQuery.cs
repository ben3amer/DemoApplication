using MediatR;

namespace Application.Customer.Queries.GetCustomerById;
public class GetCustomerByIdQuery : IRequest<CustomerDetailVm>
{
    public GetCustomerByIdQuery(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}
