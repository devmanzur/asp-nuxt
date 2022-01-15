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

        var kidsFashionCategory = new Category("Kids Fashion", "Kids Fashion categories");
        kidsFashionCategory.AddProducts(GetKidsFashionProducts());

        return new List<Category>()
        {
            fashionCategory,
            kidsFashionCategory
        };
    }

    private List<Product> GetFashionProducts()
    {
        return new List<Product>()
        {
            new(".NET Bot Black Sweatshirt", ".NET Bot Black Sweatshirt", 19.5M,
                "https://images.unsplash.com/photo-1583743814966-8936f5b7be1a?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1974&q=80"),
            new(".NET Black & White Mug", ".NET Black & White Mug", 8.50M,
                "https://images.unsplash.com/photo-1503341504253-dff4815485f1?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTV8fHQlMjBzaGlydHxlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60"),
            new("Prism White T-Shirt", "Prism White T-Shirt", 12,
                "https://images.unsplash.com/photo-1488716820095-cbe80883c496?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=686&q=80"),
            new(".NET Foundation Sweatshirt", ".NET Foundation Sweatshirt", 12,
                "https://images.unsplash.com/photo-1571945153237-4929e783af4a?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=687&q=80"),
            new("Roslyn Red Sheet", "Roslyn Red Sheet", 8.5M,
                "https://images.unsplash.com/photo-1622470953794-aa9c70b0fb9d?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mjl8fHQlMjBzaGlydHxlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60"),
            new(".NET Blue Sweatshirt", ".NET Blue Sweatshirt", 12,
                "https://images.unsplash.com/photo-1627225793904-a2f900a6e4cf?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1974&q=80"),
            new("Roslyn Red T-Shirt", "Roslyn Red T-Shirt", 12,
                "https://images.unsplash.com/photo-1578587018452-892bacefd3f2?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=687&q=80"),
            new("Kudu Purple Sweatshirt", "Kudu Purple Sweatshirt", 8.5M,
                "https://images.unsplash.com/photo-1608175602591-d1807a0850dd?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=687&q=80"),
            new("Prism White TShirt", "Prism White TShirt", 12,
                "https://images.unsplash.com/photo-1582418701181-fb023bad8b4d?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=715&q=80")
        };
    }

    private List<Product> GetKidsFashionProducts()
    {
        return new List<Product>()
        {
            new("Kids Jacket", "Kids Jacket", 19.5M,
                "https://images.unsplash.com/photo-1596870230751-ebdfce98ec42?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8a2lkcyUyMGZhc2hpb258ZW58MHx8MHx8&auto=format&fit=crop&w=500&q=60"),
            new("Kids blue jacket and pants", "Kids blue jacket and pants", 8.50M,
                "https://images.unsplash.com/photo-1519238263530-99bdd11df2ea?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8a2lkcyUyMGZhc2hpb258ZW58MHx8MHx8&auto=format&fit=crop&w=500&q=60"),
            new("Girls White Tops", "Girls White Tops", 12,
                "https://images.unsplash.com/photo-1518831959646-742c3a14ebf7?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Nnx8a2lkcyUyMGZhc2hpb258ZW58MHx8MHx8&auto=format&fit=crop&w=500&q=60"),
            new("Girls hat and dress", "Girls hat and dress", 12,
                "https://images.unsplash.com/photo-1590480598135-3be152c87913?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NXx8a2lkcyUyMGZhc2hpb258ZW58MHx8MHx8&auto=format&fit=crop&w=500&q=60"),
            new("Boys stylish t-shirt with jacket", "Boys stylish t-shirt with jacket", 8.5M,
                "https://images.unsplash.com/photo-1584847689007-3a9fe6ba7132?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8OXx8a2lkcyUyMGZhc2hpb258ZW58MHx8MHx8&auto=format&fit=crop&w=500&q=60"),
            new("Girls head band and tops", "Girls head band and tops", 12,
                "https://images.unsplash.com/photo-1613456209686-a89d1e2024ab?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTJ8fGtpZHMlMjBmYXNoaW9ufGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=500&q=60"),
            new("Styled shirts with matching pants", "Styled shirts with matching pants", 12,
                "https://images.unsplash.com/photo-1502451885777-16c98b07834a?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTZ8fGtpZHMlMjBmYXNoaW9ufGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=500&q=60"),
            new("Kids tank top", "Kids tank top", 8.5M,
                "https://images.unsplash.com/photo-1541015492536-31d513c59861?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTV8fGtpZHMlMjBmYXNoaW9ufGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=500&q=60"),
            new("Matching set for girls", "Matching set for girls", 12,
                "https://images.unsplash.com/photo-1525507119028-ed4c629a60a3?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTh8fGtpZHMlMjBmYXNoaW9ufGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=500&q=60")
        };
    }

    #endregion
}