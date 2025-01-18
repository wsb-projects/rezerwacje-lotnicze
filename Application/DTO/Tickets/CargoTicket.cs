using System.Text.Json.Serialization;

namespace rezerwacje_lotnicze.Application.DTO.Tickets;

public class CargoTicket : Ticket
{
    [JsonPropertyName("weight")]
    public int Weight { get; set; }
    [JsonPropertyName("volume")]
    public int Volume { get; set; }
}
