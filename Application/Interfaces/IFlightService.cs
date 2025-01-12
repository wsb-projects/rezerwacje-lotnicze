using rezerwacje_lotnicze.Domain.Entities.Flights;

namespace rezerwacje_lotnicze.Application.Interfaces
{
    public interface IFlightService
    {
        Task<ICollection<BaseFlight>> GetFlights();
    }
}