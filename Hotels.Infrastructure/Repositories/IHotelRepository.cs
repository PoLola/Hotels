using Hotels.Domain.Entities;

namespace Hotels.Infrastructure.Repositories
{
    public interface IHotelRepository : IBaseRepository
    {
        Task<long> CreateHotel(Hotel hotel);

        Task<long> CreateRoom(Room room);

        Task<bool> IsHotelExists(long hotelId);

        Task<Hotel?> GetHotelById(long hotelId);

        Task<Room?> GetRoomById(long roomId);

        Task<List<Reservation>?> GetReservationsById(long agencyId);
    }
}
