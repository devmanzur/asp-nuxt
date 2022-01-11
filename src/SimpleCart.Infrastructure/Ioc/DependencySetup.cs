using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleCart.Core.Interfaces;
using SimpleCart.Core.Models.Users;
using SimpleCart.Infrastructure.Persistence;
using SimpleCart.Infrastructure.Utils;

namespace SimpleCart.Infrastructure.Ioc;

public static class DependencySetup
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDatabaseContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SimpleCartDb")));
        services.AddScoped<IUnitOfWork>(provider => provider.GetService<ApplicationDatabaseContext>()!);
        services.AddHostedService<DatabaseSeedingService>();
        services.AddMediatR(typeof(ApplicationUser));
    }
}