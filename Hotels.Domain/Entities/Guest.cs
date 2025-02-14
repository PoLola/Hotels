using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hotels.Domain.Entities
{
    [Table("guest")]
    public class Guest : BaseModel
    {
        [Key]
        [Column("guestid")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id { get; set; }

        [Column("reservationid")]
        public long ReservationId { get; set; }

        [ForeignKey("ReservationId")]
        public Reservation Reservation { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("birthdate")]
        public DateTime Birthdate { get; set; }

        [Column("gender")]
        public string Gender { get; set; }

        [Column("identificationtype")]
        public string IdentificationType { get; set; }

        [Column("identificationnumber")]
        public string IdentificationNumber { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("phone")]
        public string Phone { get; set; }
    }
}
