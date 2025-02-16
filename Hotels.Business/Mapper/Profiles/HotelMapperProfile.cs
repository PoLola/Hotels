using AutoMapper;
using Hotels.Domain.Entities;
using Hotels.Domain.Models;
using Hotels.Domain.Request;

namespace Hotels.Business.Mapper.Profiles
{
    public class HotelMapperProfile : Profile
    {
        public HotelMapperProfile()
        {
            CreateMap<SaveHotelRequest, Hotel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Rooms, opt => opt.Ignore());

            CreateMap<SaveRoomRequest, RoomDto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.HotelId, opt => opt.Ignore())
                .ForMember(dest => dest.Hotel, opt => opt.Ignore());

            CreateMap<Reservation, ReservationDto>();
        }
    }
}
