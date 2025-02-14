﻿using Hotels.Domain.Entities;
using Hotels.Domain.Models;
using Hotels.Domain.Request;

namespace Hotels.Business.Mapper
{
    public interface IHotelMapperService
    {
        Hotel MapToHotelEntity(SaveHotelRequest request, Hotel? entity = null);

        Room MapToRoomEntity(SaveRoomRequest request, long? parentId = null, Room? entity = null);

        ReservationDto MapEntityToReservationDto(Reservation request);
    }
}
