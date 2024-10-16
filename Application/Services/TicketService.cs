using rezerwacje_lotnicze.Application.Interfaces;
using rezerwacje_lotnicze.Domain.Entities.Tickets;

namespace rezerwacje_lotnicze.Application.Services
{
    public class TicketService : ITicketService
    {
        public Task<BaseTicket> GetFlightAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

