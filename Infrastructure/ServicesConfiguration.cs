using Application.Common;
using Application.Repositories;
using Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace Infrastructure;
public static class ServicesConfiguration 
{
    public static IServiceCollection AddPersistence (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDateTime, MachineDateTime>();
        services.AddTransient<INotificationService, NotificationService>();
        services.AddDbContext<DemoDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default") ?? throw new InvalidOperationException()));
        services.AddScoped<IDemoDbContext, DemoDbContext>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        
        return services;
    }
}
