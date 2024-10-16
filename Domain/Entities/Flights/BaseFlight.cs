using System.ComponentModel.DataAnnotations;

namespace rezerwacje_lotnicze.Domain.Entities.Flights
{
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

