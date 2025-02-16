namespace Hotels.Domain.Request
{
    public record GetRoomResponse(
        decimal Price,
        decimal Taxes,
        string Type,
        string Location,
        bool IsEnabled = false
    );
}
