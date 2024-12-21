using Microsoft.AspNetCore.Mvc;
using rezerwacje_lotnicze.Application.Interfaces;

namespace rezerwacje_lotnicze.Api.Controllers
{
    /// <summary>
    /// Controller for managing ticket operations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // GET: api/Ticket
        // Returns all tickets in the system
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaseTicket>>> GetAllTickets()
        {
            var tickets = await _ticketService.GetAllTicketsAsync();
            return Ok(tickets);
        }

        // GET: api/Ticket/{id}
        // Returns a specific ticket by its ID
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseTicket>> GetTicket(int id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            if (ticket == null) return NotFound();
            return Ok(ticket);
        }

        // POST: api/Ticket
        // Creates a new ticket based on the provided data
        [HttpPost]
        public async Task<ActionResult<BaseTicket>> CreateTicket([FromBody] TicketCreateDto ticketDto)
        {
            var ticket = await _ticketService.CreateTicketAsync(ticketDto);
            return CreatedAtAction(nameof(GetTicket), new { id = ticket.Id }, ticket);
        }

        // PUT: api/Ticket/{id}
        // Updates an existing ticket with the provided data
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, [FromBody] TicketUpdateDto ticketDto)
        {
            var result = await _ticketService.UpdateTicketAsync(id, ticketDto);
            if (!result) return NotFound();
            return NoContent();
        }

        // DELETE: api/Ticket/{id}
        // Removes a ticket from the system
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var result = await _ticketService.DeleteTicketAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

        // GET: api/Ticket/flight/{flightId}
        // Returns all tickets associated with a specific flight
        [HttpGet("flight/{flightId}")]
        public async Task<ActionResult<IEnumerable<BaseTicket>>> GetTicketsByFlight(int flightId)
        {
            var tickets = await _ticketService.GetTicketsByFlightAsync(flightId);
            return Ok(tickets);
        }
    }
}