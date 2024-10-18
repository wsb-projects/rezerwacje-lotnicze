using Microsoft.AspNetCore.Mvc;
using rezerwacje_lotnicze.Application.Interfaces;

namespace rezerwacje_lotnicze.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
    
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
    }
}