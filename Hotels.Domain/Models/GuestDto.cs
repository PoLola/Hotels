using System.ComponentModel.DataAnnotations.Schema;

namespace Hotels.Domain.Models
{
    public class GuestDto
    {
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public string Gender { get; set; }

        public string IdentificationType { get; set; }

        public string IdentificationNumber { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
