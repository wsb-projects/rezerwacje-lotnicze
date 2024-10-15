namespace DefaultNamespace;


public abstract class BaseTicket
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }

    public ICollection<BaseFlight> Flights { get; set; } = new List<BaseFlight>();
}