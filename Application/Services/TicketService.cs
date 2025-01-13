using Microsoft.EntityFrameworkCore;
using rezerwacje_lotnicze.Application.Interfaces;
using rezerwacje_lotnicze.Domain.Entities.Tickets;
using rezerwacje_lotnicze.Infrastructure;

namespace rezerwacje_lotnicze.Application.Services
{
    public class TicketService : ITicketService
    {

        private readonly FlightBookingDbContext _databaseService;

        public TicketService(FlightBookingDbContext databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<ICollection<BaseTicket>> GetTickets(string userId)
        {
            return await _databaseService.Tickets.Where(t => t.UserId == userId).Include(t => t.Flight).ToListAsync();
        }

        public async Task AddTicket<T>(string userId, T t) where T : DTO.Tickets.Ticket
        {
            var flight = await _databaseService.Flights.FirstOrDefaultAsync(f => f.Id == t.FlightId) 
                         ?? throw new ArgumentException("Flight not found");
            
            BaseTicket ticket = t switch
            {
                DTO.Tickets.PassengerTicket passengerTicket => new PassengerTicket
                {
                    UserId = userId,
                    NumberOfSeats = passengerTicket.NumberOfSeats,
                    Flight = flight,
                },
                DTO.Tickets.CargoTicket cargoTicket => new CargoTicket
                {
                    UserId = userId,
                    CargoWeight = cargoTicket.Weight,
                    CargoVolume = cargoTicket.Volume,
                    Flight = flight,
                },
                _ => throw new ArgumentException("Invalid ticket type")

            };
            await _databaseService.Tickets.AddAsync(ticket);
            await _databaseService.SaveChangesAsync();
        }
    }
}
