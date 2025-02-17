using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hotels.Domain.Models
{
    public class RoomDto
    {
        public long Id { get; set; }

        public long HotelId { get; set; }

        public HotelDto Hotel { get; set; }

        public bool IsEnabled { get; set; }

        public decimal Price { get; set; }

        public decimal Taxes { get; set; }

        public string Type { get; set; }

        public string Location { get; set; }

        public int MaxCapacity { get; set; }
    }
}
