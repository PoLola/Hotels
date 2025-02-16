using System.Threading.Tasks;
using Hotels.Domain.Entities;
using Hotels.Domain.Models;

namespace Hotels.Infrastructure.Repositories
{
    public interface IHotelRepository : IBaseRepository
    {
        Task<long> CreateHotel(Hotel hotel);

        Task<long> CreateRoom(Room room);

        Task<bool> IsHotelExists(long hotelId);

        Task<Hotel?> GetHotelById(long hotelId);

        Task<Room?> GetRoomById(long roomId);

        Task DeleteHotelById(long hotelId);
        Task DeleteRoomById(long roomId);
        Task<bool> IsRoomExists(long roomId);
        Task<List<Reservation>> GetReservationsById(GetResevationRequestDto getResevationRequestDto);
    }
}
