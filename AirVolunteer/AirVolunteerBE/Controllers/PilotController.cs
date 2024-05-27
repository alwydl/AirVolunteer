using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Repositories;

namespace AirVolunteerBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PilotController : ControllerBase
    {
        [HttpGet]
        [Route("GetPilotInfo")]
        public PilotMOD GetPilotInfo(Guid pilotID)
        {
            return PilotREP.Get(pilotID);
        }

        [HttpPost]
        [Route("PostPilotInfo")] 
        public PilotMOD PostPilotInfo([FromBody] PilotMOD pilot)
        {
            pilot = PilotREP.Add(pilot);
            return pilot;
        }
    }
}
