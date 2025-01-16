using Microsoft.AspNetCore.Mvc;
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

        public async Task<BaseFlight> AddFlight(BaseFlight flight)
        {
            if (flight == null)
            {
                throw new ArgumentNullException();
            }

            await _databaseService.Flights.AddAsync(flight);
            await _databaseService.SaveChangesAsync();
            return flight;
        }
        
        public async Task<bool> DeleteFlight(int flightId)
        {
            var flight = await _databaseService.Flights.FindAsync(flightId);
            if (flight == null)
            {
                return false;
            }

            _databaseService.Flights.Remove(flight);
            await _databaseService.SaveChangesAsync();
            return true;
        }
    }
}