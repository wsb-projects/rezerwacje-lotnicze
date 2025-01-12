using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace rezerwacje_lotnicze.Domain.Entities.Flights
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "flightType")]
    [JsonDerivedType(typeof(PassengerFlight), typeDiscriminator: "0")]
    [JsonDerivedType(typeof(CargoFlight), typeDiscriminator: "1")]
    public abstract class BaseFlight
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        public FlightType FlightType { get; protected set; }

        [Required]
        [StringLength(60, ErrorMessage = "Departure location cannot exceed 60 characters.")]
        public string DepartureLocation { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "Arrival location cannot exceed 60 characters.")]
        public string ArrivalLocation { get; set; }

        [Required]
        public DateTime DepartureDate { get; set; }

        [Required]
        public DateTime ArrivalDate { get; set; }
    }
}
