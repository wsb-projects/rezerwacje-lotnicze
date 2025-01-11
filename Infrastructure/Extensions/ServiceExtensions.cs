using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using rezerwacje_lotnicze.Infrastructure;
using rezerwacje_lotnicze.Infrastructure.Seeders;

namespace rezerwacje_lotnicze.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void SeedDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<FlightBookingDbContext>();
            var flightSeeder = scope.ServiceProvider.GetRequiredService<FlightSeeder>();

            flightSeeder.SeedAsync().Wait();
        }
    }
}