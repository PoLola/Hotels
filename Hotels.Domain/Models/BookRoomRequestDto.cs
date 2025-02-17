using Hotels.Domain.Request;

namespace Hotels.Domain.Models
{
    public record BookRoomRequestDto(
        BookRoomRequest Data,
        long RoomId
     
    );
}
