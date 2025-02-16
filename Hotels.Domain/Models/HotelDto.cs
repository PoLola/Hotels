using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hotels.Domain.Models
{
    public class HotelDto
    {
        public long Id { get; set; }

        public long AgencyId { get; set; }

        public bool IsEnabled { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }

        public ICollection<RoomDto> Rooms { get; set; } = [];
    }
}
