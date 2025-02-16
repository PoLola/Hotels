namespace Hotels.Domain.Response
{
    public record GetRoomResponse(
        string Address,
        string HotelName,
        List<GetRoomDto> Rooms
    );

    public record GetRoomDto(
    long Id,
    decimal Price,
    decimal Taxes,
    string Type,
    string Location,
    int MaxCapacity
    );
}
