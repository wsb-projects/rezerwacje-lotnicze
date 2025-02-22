using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.IdentityModel.Tokens;
using rezerwacje_lotnicze.Application.Interfaces;
using rezerwacje_lotnicze.Domain.Entities.User;
using rezerwacje_lotnicze.Infrastructure.Identity;

namespace rezerwacje_lotnicze.Infrastructure.Extensions;

public static class IdentityExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();

        services.AddIdentityCore<User>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<FlightBookingDbContext>()
            .AddSignInManager();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "http://localhost:8080",
                    ValidAudience = "http://localhost:8080",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yourSuperSecretKeyThatIsSuperSecret")),
                    ClockSkew = TimeSpan.Zero
                };
                
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
            });

        services.AddAuthorization();

        return services;
    }
    
    public static void MapIdentityRoutes(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapIdentityApi<User>();
    }
}