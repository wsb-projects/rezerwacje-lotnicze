using Microsoft.AspNetCore.Mvc;
using rezerwacje_lotnicze.Domain.Entities.Flights;

namespace rezerwacje_lotnicze.Application.Interfaces
{
    public interface IFlightService
    {
        Task<ICollection<BaseFlight>> GetFlights();
        Task<BaseFlight> AddFlight(BaseFlight flight);
        Task<bool> DeleteFlight(int flightId);
    }
}