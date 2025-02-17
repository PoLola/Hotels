using Hotels.Domain.Entities;

namespace Hotels.Domain.Models
{
    public class ReservationDto
    {
        public long Id { get; set; }
        public string EmergencyName { get; set; }
        public string EmergencyPhone { get; set; }
        public long RoomId { get; set; }
        public RoomDto Room { get; set; }
        public ICollection<GuestDto> Guests { get; set; } = [];
    };
}
