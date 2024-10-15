namespace DefaultNamespace;

public class User
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    public ICollection<BaseTicket> Tickets { get; set; } = new List<BaseTicket>();
}