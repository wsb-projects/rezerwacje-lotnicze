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
    }
}
