using Microsoft.AspNetCore.Mvc;
using rezerwacje_lotnicze.Application.Interfaces;

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
    }
}