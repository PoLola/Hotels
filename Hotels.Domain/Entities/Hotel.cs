using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hotels.Domain.Entities
{
    [Table("hotels")]
    public class Hotel : BaseModel
    {
        [Key]
        [Column("hotelid")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id { get; set; }

        [Column("agencyid")]
        public long AgencyId { get; set; }

        [Column("isenabled")]
        public bool IsEnabled { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [InverseProperty("Hotel")]
        public ICollection<Room> Rooms { get; set; } = [];
    }
}
