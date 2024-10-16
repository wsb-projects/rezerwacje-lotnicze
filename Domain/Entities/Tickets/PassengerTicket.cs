using System.ComponentModel.DataAnnotations;

namespace rezerwacje_lotnicze.Domain.Entities.Tickets
{
    public class PassengerTicket : BaseTicket
    {
        [Required]
        public int NumberOfSeats { get; set; }

        public PassengerTicket()
        {
            TicketType = TicketType.PassengerTicket;
        }
    }
}

