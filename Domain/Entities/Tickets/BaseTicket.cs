namespace DefaultNamespace
    
public abstract class BaseTicket
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("User")]
    public int UserId { get; set; }

    public User User { get; set; }

    [Required]
    public TicketType TicketType { get; protected set; }

    public ICollection<BaseFlight> Flights { get; set; } = new List<BaseFlight>();
}
