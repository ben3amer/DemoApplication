using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;
public class DemoDbContextFactory: DesignTimeDbContextFactoryBase<DemoDbContext>
{
    protected override DemoDbContext CreateNewInstance(DbContextOptions<DemoDbContext> options)
    {
        return new DemoDbContext(options);
    }
}
