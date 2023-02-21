using Application.Common;
using Domain.Common;
using Domain.Entities.Customer;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;
public class DemoDbContext : DbContext, IDemoDbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DemoDbContext(DbContextOptions<DemoDbContext> options,DbSet<Customer> customers) 
        : base(options)
    {
        Customers = customers;
    }
    public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
    {
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseAuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedOn = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedOn = DateTime.Now;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DemoDbContext).Assembly);
    }
}
