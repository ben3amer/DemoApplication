using Application.Common;
using Application.Customer.Command.CreateCustomer;
using Application.Customer.Queries.GetCustomersList;
using Application.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.Customer;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;
public class CustomerRepository : ICustomerRepository
{
    private readonly IDemoDbContext _context;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    public CustomerRepository(IDemoDbContext context, IMapper mapper, IMediator mediator)
    {
        _context = context;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        return await _context.Customers.AsNoTracking()
            .FirstOrDefaultAsync(customer => customer.Id == id);
    }
    public async Task<List<CustomerDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Customers
            .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
    public async Task AddAsync(Customer customer, CancellationToken cancellationToken)
    {
        
         _context.Customers.Add(customer);
        await _context.SaveChangesAsync(cancellationToken);
        await _mediator.Publish(new CustomerCreated
        {
            Id = customer.Id
        }, cancellationToken);
        
    }
    public async Task UpdateAsync(Customer customer, CancellationToken cancellationToken)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync(cancellationToken);
    }
    public async Task DeleteAsync(Customer customer,CancellationToken cancellationToken)
    {
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
