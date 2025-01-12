using Microsoft.AspNetCore.Mvc;
using rezerwacje_lotnicze.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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

        [Authorize]
        [HttpGet("GetTickets")]
        public async Task<IActionResult> GetTickets()
        {
            if (!User.Identity?.IsAuthenticated ?? false)
            {
                return Unauthorized();
            }

            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value; // Get user ID or other claim
            return Ok(await _ticketService.GetTickets(userId));
        }
    }
}
