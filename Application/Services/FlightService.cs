using Microsoft.EntityFrameworkCore;
using rezerwacje_lotnicze.Application.Interfaces;
using rezerwacje_lotnicze.Domain.Entities.Flights;
using rezerwacje_lotnicze.Infrastructure;

namespace rezerwacje_lotnicze.Application.Services
{
    public class FlightService : IFlightService
    {
        private readonly FlightBookingDbContext _databaseService;

        public FlightService(FlightBookingDbContext databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<ICollection<BaseFlight>> GetFlights()
        {
            return await _databaseService.Flights.ToListAsync();
        }
    }
}