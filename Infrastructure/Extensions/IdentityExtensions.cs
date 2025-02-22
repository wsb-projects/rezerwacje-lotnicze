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

        services.AddCors(options =>
        {
            options.AddPolicy(name: "allowall",
                policy =>
                {
                    policy.WithOrigins("http://localhost:5173").AllowCredentials().AllowAnyHeader().AllowAnyMethod();
                });
        });

        services.AddAuthentication(options => { options.DefaultAuthenticateScheme = IdentityConstants.BearerScheme; })
            .AddBearerToken(IdentityConstants.BearerScheme);

        services.AddAuthorization();

        return services;
    }

    public static void MapIdentityRoutes(this WebApplication app)
    {
        app.UseCors("allowall");
        app.MapIdentityApi<User>();
    }
}