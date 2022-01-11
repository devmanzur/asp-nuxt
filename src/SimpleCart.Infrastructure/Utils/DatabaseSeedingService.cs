using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleCart.Core.Models.Products;
using SimpleCart.Infrastructure.Persistence;

namespace SimpleCart.Infrastructure.Utils;

public class DatabaseSeedingService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public DatabaseSeedingService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDatabaseContext>();
        if (context.Database.IsSqlServer())
        {
            await context.Database.MigrateAsync(cancellationToken);
        }

        await SeedInitialData(context, cancellationToken);
    }

    private async Task SeedInitialData(ApplicationDatabaseContext context, CancellationToken cancellationToken)
    {
        var categoryExists = await context.Categories.AnyAsync(cancellationToken: cancellationToken);
        if (!categoryExists)
        {
            var categories = GetCategories();
            context.Categories.AddRange(categories);
            await context.SaveChangesAsync(cancellationToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    #region Internal functions

    List<Category> GetCategories()
    {
        var fashionCategory = new Category("Fashion", "All Fashion categories");
        fashionCategory.AddProducts(GetFashionProducts());

        return new List<Category>()
        {
            fashionCategory
        };
    }

    private List<Product> GetFashionProducts()
    {
        return new List<Product>()
        {
            new(".NET Bot Black Sweatshirt", ".NET Bot Black Sweatshirt", 19.5M,
                "http://catalogbaseurltobereplaced/images/products/1.png"),
            new(".NET Black & White Mug", ".NET Black & White Mug", 8.50M,
                "http://catalogbaseurltobereplaced/images/products/2.png"),
            new("Prism White T-Shirt", "Prism White T-Shirt", 12,
                "http://catalogbaseurltobereplaced/images/products/3.png"),
            new(".NET Foundation Sweatshirt", ".NET Foundation Sweatshirt", 12,
                "http://catalogbaseurltobereplaced/images/products/4.png"),
            new("Roslyn Red Sheet", "Roslyn Red Sheet", 8.5M,
                "http://catalogbaseurltobereplaced/images/products/5.png"),
            new(".NET Blue Sweatshirt", ".NET Blue Sweatshirt", 12,
                "http://catalogbaseurltobereplaced/images/products/6.png"),
            new("Roslyn Red T-Shirt", "Roslyn Red T-Shirt", 12,
                "http://catalogbaseurltobereplaced/images/products/7.png"),
            new("Kudu Purple Sweatshirt", "Kudu Purple Sweatshirt", 8.5M,
                "http://catalogbaseurltobereplaced/images/products/8.png"),
            new("Prism White TShirt", "Prism White TShirt", 12,
                "http://catalogbaseurltobereplaced/images/products/12.png")
        };
    }

    #endregion
}