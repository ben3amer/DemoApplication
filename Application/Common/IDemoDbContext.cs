using Microsoft.EntityFrameworkCore;

namespace Application.Common;
public interface IDemoDbContext
{
    DbSet<Domain.Entities.Customer.Customer> Customers { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
