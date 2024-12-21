using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using rezerwacje_lotnicze.Application.Interfaces;
using rezerwacje_lotnicze.Domain.Entities.Flights;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rezerwacje_lotnicze.Api.Controllers
{
    /// <summary>
    /// Controller for managing flight operations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;

        // TODO: Add logging service injection
        // TODO: Add caching mechanism for frequently accessed flights
        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        // GET: api/Flight
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // TODO: Add pagination support
        // TODO: Implement filtering options
        public async Task<ActionResult<IEnumerable<BaseFlight>>> GetAllFlights()
        {
            try
            {
                var flights = await _flightService.GetAllFlightsAsync();
                return Ok(flights);
            }
            catch (Exception ex)
            {
                // TODO: Add logging of exception details
                return StatusCode(500, "Internal server error while retrieving flights");
            }
        }

        // GET: api/Flight/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // TODO: Add response caching
        public async Task<ActionResult<BaseFlight>> GetFlight(int id)
        {
            var flight = await _flightService.GetFlightByIdAsync(id);
            if (flight == null) 
                return NotFound($"Flight with ID {id} not found");
            return Ok(flight);
        }

        // POST: api/Flight
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // TODO: Add request validation attributes
        // TODO: Implement rate limiting
        public async Task<ActionResult<BaseFlight>> CreateFlight([FromBody] FlightCreateDto flightDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var flight = await _flightService.CreateFlightAsync(flightDto);
            return CreatedAtAction(nameof(GetFlight), new { id = flight.Id }, flight);
        }

        // PUT: api/Flight/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // TODO: Add concurrency handling
        // TODO: Implement partial updates (PATCH)
        public async Task<IActionResult> UpdateFlight(int id, [FromBody] FlightUpdateDto flightDto)
        {
            if (id <= 0)
                return BadRequest("Invalid flight ID");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _flightService.UpdateFlightAsync(id, flightDto);
            if (!result) 
                return NotFound($"Flight with ID {id} not found");
            return NoContent();
        }

        // DELETE: api/Flight/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // TODO: Add soft delete functionality
        // TODO: Implement batch delete operations
        public async Task<IActionResult> DeleteFlight(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid flight ID");

            var result = await _flightService.DeleteFlightAsync(id);
            if (!result) 
                return NotFound($"Flight with ID {id} not found");
            return NoContent();
        }
    }
}