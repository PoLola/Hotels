#pragma warning disable CA1862 // Use the 'StringComparison' method overloads to perform case-insensitive string comparisons
using Hotels.Domain.Entities;
using Hotels.Domain.Models;
using Hotels.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Hotels.Infrastructure.Repositories
{
    public class HotelRepository(IHotelContext context) : BaseRepository(context), IHotelRepository
    {
        private readonly IHotelContext _context = context;

        public async Task<long> CreateHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await SaveChanges();
            return hotel.Id;
        }

        public async Task<long> CreateRoom(Room room)
        {
            _context.Rooms.Add(room);
            await SaveChanges();
            return room.Id;
        }

        public async Task<bool> IsHotelExists(long hotelId)
        {
            return await _context.Hotels.AnyAsync(x => x.Id == hotelId);
        }

        public async Task<Hotel?> GetHotelById(long hotelId)
        {
            return await _context.Hotels.FirstOrDefaultAsync(x => x.Id == hotelId);
        }

        public async Task<Room?> GetRoomById(long roomId)
        {
            return await _context.Rooms.FirstOrDefaultAsync(x => x.Id == roomId);
        }

        public async Task<List<Reservation>?> GetReservationsById(GetResevationRequestDto getReservationRequestDto)
        {
            if (getReservationRequestDto.ReservationId.HasValue)
            {
                return await _context.Reservations.Where(x => x.Room.Hotel.AgencyId == getReservationRequestDto.AgencyId &&
                                                            x.Id == getReservationRequestDto.ReservationId).ToListAsync();
            }
            return await _context.Reservations.Where(x => x.Room.Hotel.AgencyId == getReservationRequestDto.AgencyId).ToListAsync();
        }

        public async Task DeleteHotelById(long hotelId)
        {
            await _context.Hotels.Where(x => x.Id == hotelId).ExecuteDeleteAsync();
        }

        public async Task DeleteRoomById(long roomId)
        {
            await _context.Rooms.Where(x => x.Id == roomId).ExecuteDeleteAsync();
        }

        public async Task<bool> IsRoomExists(long roomId)
        {
            return await _context.Rooms.AnyAsync(x => x.Id == roomId);
        }

    }
}
#pragma warning restore CA1862 // Use the 'StringComparison' method overloads to perform case-insensitive string comparisons
