using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleCart.Core.Interfaces;
using SimpleCart.Infrastructure.Persistence;

namespace SimpleCart.Infrastructure.Ioc;

public static class DependencySetup
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDatabaseContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SimpleCartDb")));
        services.AddScoped<IUnitOfWork>(provider => provider.GetService<ApplicationDatabaseContext>()!);

    }
}