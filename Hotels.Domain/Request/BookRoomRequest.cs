using System;
using Hotels.Domain.Models;

namespace Hotels.Domain.Request
{
    public record BookRoomRequest(
        DateTime CheckIn,
        DateTime CheckOut,
        List<GuestDto> Guests,
        string EmergencyName,
        string EmergencyPhoneNumber
    );
}
