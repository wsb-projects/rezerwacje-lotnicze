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



}
