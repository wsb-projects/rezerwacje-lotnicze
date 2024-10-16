using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using rezerwacje_lotnicze.Domain.Entities.Flights;

namespace rezerwacje_lotnicze.Domain.Entities.Tickets
{
    public abstract class BaseTicket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        
        [Required]
        public User.User User { get; set; }

        [Required]
        public TicketType TicketType { get; protected set; }

        public ICollection<BaseFlight> Flights { get; set; } = new List<BaseFlight>();
    }
}

