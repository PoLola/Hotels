using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hotels.Domain.Entities
{
    [Table("reservations")]
    public class Reservation : BaseModel
    {
        [Key]
        [Column("reservationid")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id { get; set; }

        [Column("emergencyname")]
        public string EmergencyName { get; set; }

        [Column("emergencyphone")]
        public string EmergencyPhone { get; set; }

        [Column("roomid")]
        public long RoomId { get; set; }

        [ForeignKey("RoomId")]
        public Room Room { get; set; }

        [InverseProperty("Reservation")]
        public ICollection<Guest> Guests { get; set; } = [];
    }
}
