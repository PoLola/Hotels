using AutoMapper;
using Hotels.Domain.Entities;
using Hotels.Domain.Models;
using Hotels.Domain.Request;
using Hotels.Domain.Response;

namespace Hotels.Business.Mapper.Profiles
{
    public class HotelMapperProfile : Profile
    {
        public HotelMapperProfile()
        {
            CreateMap<SaveHotelRequest, Hotel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Rooms, opt => opt.Ignore());

            CreateMap<SaveRoomRequest, Room>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.HotelId, opt => opt.Ignore())
                .ForMember(dest => dest.Hotel, opt => opt.Ignore());

            CreateMap<Reservation, ReservationDto>();

            CreateMap<Hotel, GetRoomResponse>()
                .ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

            CreateMap<Room, GetRoomDto>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Taxes, opt => opt.MapFrom(src => src.Taxes))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.MaxCapacity, opt => opt.MapFrom(src => src.MaxCapacity))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<BookRoomRequestDto, Reservation>()
                .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId))
                .ForMember(dest => dest.EmergencyName, opt => opt.MapFrom(src => src.Data.EmergencyName))
                .ForMember(dest => dest.EmergencyPhone, opt => opt.MapFrom(src => src.Data.EmergencyPhoneNumber))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<GuestDto, Guest>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ReservationId, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.IdentificationNumber, opt => opt.MapFrom(src => src.IdentificationNumber))
                .ForMember(dest => dest.IdentificationType, opt => opt.MapFrom(src => src.IdentificationType))
                .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.Birthdate))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender));


        }
    }
}
