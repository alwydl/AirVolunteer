using Shared.Database;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Repositories
{
    public class PilotREP
    {
        public static PilotMOD Get(Guid pilotID)
        {
            try
            {
                using AirVolunteerDBContext context = new();

                var query = context.Pilots.Where(s => s.Id == pilotID);

                PilotMOD pilot = query.FirstOrDefault();

                return pilot;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve the Pilot from the DB", ex);
            }
        }
        public static PilotMOD Get(long cpf)
        {
            try
            {
                using AirVolunteerDBContext context = new();

                var query = context.Pilots.Where(s => s.CPF == cpf);

                PilotMOD pilot = query.FirstOrDefault();

                return pilot;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve the Pilot from the DB", ex);
            }
        }

        public static PilotMOD Add(PilotMOD pilot)
        {
            try
            {
                using AirVolunteerDBContext context = new();

                PilotMOD models = Get(pilot.CPF);

                if (models == null)
                {
                    PilotMOD newPilot = new PilotMOD()
                    {
                        Id = Guid.NewGuid(),
                        CPF = pilot.CPF,
                        Name = pilot.Name,
                        Phone = pilot.Phone,
                    };
                    context.Pilots.Add(newPilot);
                    var count = context.SaveChanges();

                    return newPilot;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PilotREP-Add", ex);
            }
        }
    }
}
