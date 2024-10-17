using System.ComponentModel.DataAnnotations;

namespace rezerwacje_lotnicze.Domain.Entities.Flights
{
    public class PassengerFlight : BaseFlight
    {
        [Required]
        public int SeatsCapacity { get; set; }

        [Required]
        public double SeatPrice { get; set; }

        public PassengerFlight()
        {
            FlightType = FlightType.PassengerFlight;
        }
    }
}