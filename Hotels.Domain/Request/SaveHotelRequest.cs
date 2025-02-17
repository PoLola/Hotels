namespace Hotels.Domain.Request
{
    public record SaveHotelRequest(
        string Name,
        long AgencyId,
        string City,
        string Address,
        bool IsEnabled = false
    );
}
