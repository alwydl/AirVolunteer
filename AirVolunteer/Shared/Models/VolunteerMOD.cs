using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class VolunteerMOD
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public long CPF { get; set; }
        [Required]
        public long RG { get; set; }
        [Required]
        public long CouncilNumber { get; set; }
        [Required]
        public string CouncilName { get; set; }
        [Required]
        public string VolunteerType { get; set; }
        [Required]
        public string Project {  get; set; }
        [Required]
        public long PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
