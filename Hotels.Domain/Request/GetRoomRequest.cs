using System;

namespace Hotels.Domain.Request
{
    public record GetRoomRequest(
        DateTime CheckIn,
        DateTime CheckOut,
        int NumPeople,
        string City
     
    );
}
