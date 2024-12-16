using rezerwacje_lotnicze.Domain.Entities.Tickets;

namespace rezerwacje_lotnicze.Application.Interfaces
{
    public interface ITicketService
    {
        public Task<BaseTicket> GetFlightAsync(int id);
    }
}