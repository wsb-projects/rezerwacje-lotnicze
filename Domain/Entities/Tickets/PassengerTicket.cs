namespace DefaultNamespace;

public class PassengerTicket : BaseTicket
{
    [Required]
    public int NumberOfSeats { get; set; }

    public PassengerTicket()
    {
        TicketType = TicketType.PassengerTicket;
    }
}