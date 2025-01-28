using rezerwacje_lotnicze.Application.Interfaces;
using rezerwacje_lotnicze.Application.Services;

namespace rezerwacje_lotnicze.Infrastructure.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IFlightService, FlightService>();
        services.AddScoped<ITicketService, TicketService>();

        return services;
    }
}