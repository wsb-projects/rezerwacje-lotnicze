using System.ComponentModel.DataAnnotations;
using rezerwacje_lotnicze.Domain.Entities.Tickets;

namespace rezerwacje_lotnicze.Domain.Entities.User
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<BaseTicket> Tickets { get; set; } = new List<BaseTicket>();
    } 
}

