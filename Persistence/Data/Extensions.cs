namespace Persistence.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public static class Extensions
{
    public static void CreateDbIfNotExists(this IHost host)
    {
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<DatabaseContext>();
            context.Database.EnsureCreated();
            DbInitializer.Initialize(context);
        }
    }
}