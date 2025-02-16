using System;
using Hotels.Domain.Models;

namespace Hotels.Domain.Request
{
    public record BookRoomRequest(
        DateTime CheckIn,
        DateTime CheckOut,
        int NumPeople,
        int RoomId,
        List<GuestDto> Guests
     
    );
}
