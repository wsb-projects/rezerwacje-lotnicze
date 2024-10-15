namespace DefaultNamespace;

public class PassengerFlight : BaseFlight
{
    [Required]
    public int SeatsCapacity { get; set; }
    [Required]
    public double SeatPrice { get; set; }
}