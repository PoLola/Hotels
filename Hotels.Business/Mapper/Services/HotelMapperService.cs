﻿using AutoMapper;
using Hotels.Domain.Entities;
using Hotels.Domain.Models;
using Hotels.Domain.Request;
using Hotels.Domain.Response;
using System;

namespace Hotels.Business.Mapper.Services
{
    public class HotelMapperService(IMapper mapper) : IHotelMapperService
    {
        private readonly IMapper _mapper = mapper;

        public Hotel MapToHotelEntity(SaveHotelRequest request, Hotel? entity = null)
        {
            var result = _mapper.Map(request, entity ?? new Hotel());

            return result;
        }

        public Room MapToRoomEntity(SaveRoomRequest request, long? parentId = null, Room? entity = null)
        {
            var result = _mapper.Map(request, entity ?? new Room());
            if (parentId.HasValue)
                result.HotelId = parentId.Value;

            return result;
        }

        public ReservationDto MapEntityToReservationDto(Reservation entity)
        {
            var result = _mapper.Map<ReservationDto>(entity);

            return result;
        }

        public GetRoomResponse MapHotelToGetRoomsResponse(Hotel hotel)
        {
            var result = _mapper.Map<GetRoomResponse>(hotel);

            return result;

        }

        public Reservation MapBookRoomToReservation(BookRoomRequestDto bookRoomRequestDto)
        {
            var result = _mapper.Map<Reservation>(bookRoomRequestDto);

            return result;
        }
    }
}
