namespace DefaultNamespace;

public class CargoTicket : BaseTicket
{
    [Required]
    public int CargoWeight { get; set; }
        
    [Required]
    public int CargoVolume { get; set; }
}