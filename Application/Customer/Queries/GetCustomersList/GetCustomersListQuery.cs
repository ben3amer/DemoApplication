using AutoMapper;
using MediatR;
using Application.Common;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Application.Customer.Queries.GetCustomersList;
public class GetCustomersListQuery : IRequest<GetCustomersListVm>
{
    public class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, GetCustomersListVm>
    {
        private readonly IDemoDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomersListQueryHandler(IDemoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetCustomersListVm> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
        {
            var customers = await _context.Customers
                            .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken);

            return new GetCustomersListVm(customers);
        }
    }
}   
