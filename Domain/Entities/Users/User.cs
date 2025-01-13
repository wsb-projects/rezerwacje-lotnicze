using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using rezerwacje_lotnicze.Domain.Entities.Tickets;

namespace rezerwacje_lotnicze.Domain.Entities.User
{
    public class User : IdentityUser
    {
        public ICollection<BaseTicket> Tickets { get; set; } = new List<BaseTicket>();
    }
}
