namespace Hotels.Domain.Models
{
    public record GetResevationRequestDto
    {
        public long AgencyId { get; set; }
        public long? ReservationId { get; set; }
       
    };
}
