using Hotels.Domain.Request;

namespace Hotels.Domain.Response
{
    public record BookRoomResponse(
        long id,
        BookRoomRequest BookRoomRequest
    );

}
