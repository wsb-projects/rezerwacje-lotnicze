using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using rezerwacje_lotnicze.Domain.Entities.Flights;

namespace rezerwacje_lotnicze.Domain.Entities.Tickets
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "ticketType")]
    [JsonDerivedType(typeof(PassengerTicket), typeDiscriminator: "0")]
    [JsonDerivedType(typeof(CargoTicket), typeDiscriminator: "1")]
    public abstract class BaseTicket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }

        [Required]
        public User.User User { get; set; }

        [Required]
        public TicketType TicketType { get; protected set; }

        public BaseFlight Flight { get; set; }
    }
}
