using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Shared.Models
{
    public class FlightMOD
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string OriginAirport { get; set; }
        [Required]
        public string DestinyAirport { get; set; }
        [Required]
        public string AirplaneModel { get; set; }
        [Required]
        public int PaxPositionsAvailable { get; set; }
        [Required]
        public int FullPaxMaxLoad { get; set; }
        [Required]
        public Guid PilotId { get; set; }
        public virtual PilotMOD? Pilot { get; set; }
        [Required]
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        [NotMapped]
        public DateTime DepartureLocalTime
        {
            get
            {
                return Departure.ToLocalTime();
            }
        }
        [NotMapped]
        public DateTime ArrivalLocalTime
        {
            get
            {
                return Arrival.ToLocalTime();
            }
        }
    }
}
