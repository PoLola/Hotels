namespace Hotels.Domain.Request
{
    public record SaveHotelRequest(
        string Name,
        long AgencyId,
        bool IsEnabled = false
    );
}
