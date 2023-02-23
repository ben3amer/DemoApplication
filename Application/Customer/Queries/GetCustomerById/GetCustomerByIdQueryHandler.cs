using Application.Common;
using Application.Common.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Customer.Queries.GetCustomerById;

public class GetCustomerDetailQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDetailVm>
{
    private readonly IDemoDbContext _context;
    private readonly IMapper _mapper;

    public GetCustomerDetailQueryHandler(IDemoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CustomerDetailVm> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Customers
            .FindAsync(new object?[]
            {
                request.Id
            }, cancellationToken: cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Customer), request.Id);
        }

        return _mapper.Map<CustomerDetailVm>(entity);
    }
}
