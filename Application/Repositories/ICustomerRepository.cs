using Application.Customer.Queries.GetCustomersList;

namespace Application.Repositories;
public interface ICustomerRepository
{ 
    Task<Domain.Entities.Customer.Customer?> GetByIdAsync(int id);
    Task<List<CustomerDto>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Domain.Entities.Customer.Customer customer, CancellationToken cancellationToken);
    Task UpdateAsync(Domain.Entities.Customer.Customer customer, CancellationToken cancellationToken);
    Task DeleteAsync(Domain.Entities.Customer.Customer customer, CancellationToken cancellationToken);
}
