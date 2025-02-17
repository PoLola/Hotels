namespace Hotels.Domain.Response
{
    public record GetRoomResponse
    {
        public string Address { get; set; }
        public string HotelName { get; set; }
        public List<GetRoomDto> Rooms { get; set; }
    }

    public record GetRoomDto
    {
        public long Id { get; set; }
        public decimal Price { get; set; }
        public decimal Taxes { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public int MaxCapacity { get; set; }
    }
}