using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hotels.Domain.Entities
{
    [Table("rooms")]
    public class Room : BaseModel
    {
        [Key]
        [Column("roomid")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id { get; set; }

        [Column("hotelid")]
        public long HotelId { get; set; }

        [Column("HotelId")]
        public Hotel Hotel { get; set; }

        [Column("isenabled")]
        public bool IsEnabled { get; set; }

        [ForeignKey("price")]
        public decimal Price { get; set; }

        [Column("taxes")]
        public decimal Taxes { get; set; }

        [Column("type")]
        public string Type { get; set; }

        [Column("location")]
        public string Location { get; set; }

        [Column("maxcapacity")]
        public int MaxCapacity { get; set; }
    }
}
