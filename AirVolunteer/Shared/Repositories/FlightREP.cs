using Shared.Database;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Repositories
{
    public static class FlightREP
    {
        public static List<FlightMOD> Get(Guid pilotID)
        {
            try
            {
                using AirVolunteerDBContext context = new();

                var query = context.Flights.Where(s => s.PilotId == pilotID);

                var Flights = query.ToList();

                return Flights;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve the flights from the DB", ex);
            }
        }

        public static List<FlightMOD> Add(FlightMOD flight)
        {
            try
            {
                using AirVolunteerDBContext context = new();

                flight.Id = Guid.NewGuid();
                context.Flights.Add(flight);
                var count = context.SaveChanges();

                return context.Flights.Where(x => x.PilotId == flight.PilotId 
                                                    && x.Departure >= DateTime.UtcNow).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("PilotREP-Add", ex);
            }
        }
    }
}
