using System.Text.Json.Serialization;

namespace rezerwacje_lotnicze.Application.DTO.Tickets
{

    [JsonPolymorphic(TypeDiscriminatorPropertyName = "ticketType")]
    [JsonDerivedType(typeof(PassengerTicket), typeDiscriminator: "passenger")]
    [JsonDerivedType(typeof(CargoTicket), typeDiscriminator: "cargo")]
    public class Ticket
    {
        [JsonPropertyName("flightID")]
        public int FlightId { get; set; }
    }

    public class PassengerTicket : Ticket
    {
        [JsonPropertyName("seats")]
        public int NumberOfSeats { get; set; }
    }

    public class CargoTicket : Ticket
    {
        [JsonPropertyName("weight")]
        public int Weight { get; set; }
        [JsonPropertyName("volume")]
        public int Volume { get; set; }
    }
}
