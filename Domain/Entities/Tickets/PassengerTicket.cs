namespace DefaultNamespace;

public class PassengerTicket : BaseTicket
{
    [Required]
    public int NumberOfSeats { get; set; }
}