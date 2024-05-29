﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Repositories;

namespace AirVolunteerBE.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class VolunteerController : ControllerBase
    {
        [HttpPost]
        [Route("PostVolunteerInfo")]
        public VolunteerMOD PostPilotInfo([FromBody] VolunteerMOD volunteer)
        {
            volunteer = VolunteerREP.Add(volunteer);
            return volunteer;
        }

        [HttpGet]
        [Route("GetVolunteerId")]
        public Guid GetVolunteerId(long cpf)
        {
            return VolunteerREP.Get(cpf).Id;
        }
    }
}
