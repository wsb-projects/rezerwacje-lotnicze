using Microsoft.AspNetCore.Identity;
using rezerwacje_lotnicze.Domain.Entities.User;

namespace rezerwacje_lotnicze.Infrastructure.Extensions;

public static class IdentityExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services)
    {
        services.AddIdentityCore<User>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<FlightBookingDbContext>()
            .AddApiEndpoints();

        services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);
        
        services.AddAuthorization();

        return services;
    }
    
    public static void MapIdentityRoutes(this WebApplication app)
    {
        app.MapIdentityApi<User>();
    }
}