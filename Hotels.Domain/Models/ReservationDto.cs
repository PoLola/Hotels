using Hotels.Domain.Entities;

namespace Hotels.Domain.Models
{
    public class ReservationDto
    {
        public string EmergencyName { get; set; }
        public string EmergencyPhone { get; set; }
        public long RoomId { get; set; }
        public Room Room { get; set; }
        public ICollection<Guest> Guests { get; set; } = [];
    };
}
