using Shared.Database;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Repositories
{
    public class VolunteerREP
    {
        public static VolunteerMOD Get(long cpf)
        {
            try
            {
                using AirVolunteerDBContext context = new();

                var query = context.Volunteers.Where(s => s.CPF == cpf);

                VolunteerMOD volunteer = query.FirstOrDefault();

                return volunteer;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve the Volunteer from the DB", ex);
            }
        }
        public static VolunteerMOD Add(VolunteerMOD volunteer)
        {
            try
            {
                using AirVolunteerDBContext context = new();

                VolunteerMOD models = Get(volunteer.CPF);

                if (models == null)
                {
                    VolunteerMOD newVolunteer = new VolunteerMOD()
                    {
                        Id = Guid.NewGuid(),
                        CPF = volunteer.CPF,
                        Name = volunteer.Name,
                        CouncilName = volunteer.CouncilName,
                        CouncilNumber = volunteer.CouncilNumber,
                        Email = volunteer.Email,
                        PhoneNumber = volunteer.PhoneNumber,
                        Project = volunteer.Project,
                        RG = volunteer.RG,
                        VolunteerType = volunteer.VolunteerType
                    };
                    context.Volunteers.Add(newVolunteer);
                    var count = context.SaveChanges();

                    return newVolunteer;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("VolunteerREP-Add", ex);
            }
        }
    }
}
