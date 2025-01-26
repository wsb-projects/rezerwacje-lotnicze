using rezerwacje_lotnicze.Infrastructure.Seeders;

namespace rezerwacje_lotnicze.Infrastructure.Extensions
{
    public static class SeederExtensions
    {
        public static IServiceCollection RegisterSeeders(this IServiceCollection services)
        {
            services.AddScoped<UserSeeder>();
            services.AddScoped<FlightSeeder>();
            
            return services;
        }
        
        public static async Task SeedDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var flightSeeder = scope.ServiceProvider.GetRequiredService<FlightSeeder>();
            var userSeeder = scope.ServiceProvider.GetRequiredService<UserSeeder>();

            await flightSeeder.SeedAsync();
            await userSeeder.SeedAsync();
        }
    }
}