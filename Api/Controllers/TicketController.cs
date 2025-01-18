using Microsoft.AspNetCore.Mvc;
using rezerwacje_lotnicze.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using rezerwacje_lotnicze.Domain.Entities.Tickets;
using rezerwacje_lotnicze.Application.DTO.Tickets;

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
        [HttpGet("Tickets")]
        public async Task<IActionResult> GetTickets()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // Get user ID or other claim
            if (!User.Identity?.IsAuthenticated ?? false || userId == null)
            {
                return Unauthorized();
            }

            return Ok(await _ticketService.GetTickets(userId));
        }

        [Authorize]
        [HttpPost("Tickets")]
        public async Task<IActionResult> AddTicket([FromBody] Ticket ticket)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // Get user ID or other claim
            if (!User.Identity?.IsAuthenticated ?? false || userId is null)
            {
                return Unauthorized();
            }
            
            await _ticketService.AddTicket(userId, ticket);

            return Ok(ticket);
        }
    }
}
