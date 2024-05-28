using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Repositories;

namespace AirVolunteerBE.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class FlightsController : ControllerBase
    {
        [HttpGet]
        [Route("GetPilotFlightsInfo")]
        public List<FlightMOD> GetPilotFlightsInfo(Guid pilotID)
        {
            return FlightREP.Get(pilotID);
        }

        [HttpPost]
        [Route("PostFlightInfo")]
        public List<FlightMOD> PostFlightInfo([FromBody] FlightMOD flight)
        {
            var flights = FlightREP.Add(flight);
            return flights;
        }
    }
}
