namespace DefaultNamespace;

public class CargoFlight : BaseFlight
{
    [Required]
    public int CargoWeight { get; set; }
    [Required]
    public int CargoVolume { get; set; }
}