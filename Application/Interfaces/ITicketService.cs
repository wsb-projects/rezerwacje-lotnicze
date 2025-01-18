using rezerwacje_lotnicze.Domain.Entities.Tickets;

namespace rezerwacje_lotnicze.Application.Interfaces
{
    public interface ITicketService
    {
        public Task<ICollection<BaseTicket>> GetTickets(string userId);
        public Task AddTicket<T>(string userId, T t) where T : DTO.Tickets.Ticket;
    }
}
