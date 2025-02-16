using System.ComponentModel.DataAnnotations.Schema;

namespace Hotels.Domain.Models
{
    public class GuestDto
    {
        public long Id { get; set; }

        public long ReservationId { get; set; }

        public ReservationDto Reservation { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public string Gender { get; set; }

        public string IdentificationType { get; set; }

        public string IdentificationNumber { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
