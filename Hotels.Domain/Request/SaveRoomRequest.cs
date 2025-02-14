namespace Hotels.Domain.Request
{
    public record SaveRoomRequest(
        decimal Price,
        decimal Taxes,
        string Type,
        string Location,
        bool IsEnabled = false
    );
}
