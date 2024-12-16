using Microsoft.EntityFrameworkCore;

namespace rezerwacje_lotnicze.Infrastructure.Extensions;

public static class DbContextExtensions
{
    public static IServiceCollection AddFlightBookingDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FlightBookingDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }

    public static void ApplyMigrations(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<FlightBookingDbContext>();
        dbContext.Database.Migrate();
    }
}