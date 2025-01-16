using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rezerwacje_lotnicze.Application.Interfaces;
using rezerwacje_lotnicze.Domain.Entities.Flights;

namespace rezerwacje_lotnicze.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet("GetFlights")]
        public async Task<IActionResult> GetFlights()
        {
            return Ok(await _flightService.GetFlights());
        }
        
        [Authorize(Roles = "admin")]
        [HttpPost("passenger-flights")]
        public async Task<IActionResult> AddPassengerFlight([FromBody] PassengerFlight flight)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _flightService.AddFlight(flight);
            return Ok(result);
        }
        
        [Authorize(Roles = "admin")]
        [HttpPost("cargo-flights")]
        public async Task<IActionResult> AddCargoFlight([FromBody] CargoFlight flight)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _flightService.AddFlight(flight);
            return Ok(result);
        }
        
        [Authorize(Roles = "admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteFlight(int flightId)
        {
            var result = await _flightService.DeleteFlight(flightId);
            return Ok(result);
        }
    }
}