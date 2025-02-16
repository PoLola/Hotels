﻿using Hotels.Domain.Entities;
using Hotels.Domain.Models;
using Hotels.Domain.Request;
using Hotels.Domain.Response;

namespace Hotels.Business.Mapper
{
    public interface IHotelMapperService
    {
        Hotel MapToHotelEntity(SaveHotelRequest request, Hotel? entity = null);

        RoomDto MapToRoomEntity(SaveRoomRequest request, long? parentId = null, RoomDto? entity = null);

        ReservationDto MapEntityToReservationDto(Reservation request);
        GetRoomResponse MapHotelToGetRoomsResponse(Hotel hotel);
    }
}
