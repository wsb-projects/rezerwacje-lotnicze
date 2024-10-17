using System.ComponentModel.DataAnnotations;

namespace rezerwacje_lotnicze.Domain.Entities.Tickets
{
    public class CargoTicket : BaseTicket
    {
        [Required]
        public int CargoWeight { get; set; }

        [Required]
        public int CargoVolume { get; set; }

        public CargoTicket()
        {
            TicketType = TicketType.CargoTicket;
        }
    }
}

