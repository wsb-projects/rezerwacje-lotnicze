using System.ComponentModel.DataAnnotations;

namespace rezerwacje_lotnicze.Domain.Entities.Flights
{
    public class CargoFlight : BaseFlight
    {
        [Required]
        public int CargoWeight { get; set; }

        [Required]
        public int CargoVolume { get; set; }

        public CargoFlight()
        {
            FlightType = FlightType.CargoFlight;
        }
    }
}