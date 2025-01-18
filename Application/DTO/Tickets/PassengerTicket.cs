using System.Text.Json.Serialization;

namespace rezerwacje_lotnicze.Application.DTO.Tickets;

public class PassengerTicket : Ticket
{
    [JsonPropertyName("seats")]
    public int NumberOfSeats { get; set; }
}
