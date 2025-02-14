#pragma warning disable CA1862 // Use the 'StringComparison' method overloads to perform case-insensitive string comparisons
using Hotels.Domain.Entities;
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

        public async Task<List<Reservation>?> GetReservationsById(long agencyId)
        {
            return await _context.Reservations.Where(x=>x.Room.Hotel.AgencyId == agencyId).ToListAsync();
        }

        //private static IQueryable<Segment> ApplySearchSegmentTemplateSort(IQueryable<Segment> query, string? sortBy, SortByDirection sortByDirection)
        //{
        //    if (string.IsNullOrEmpty(sortBy))
        //    {
        //        query = query.OrderBy(o => o.AuditCreated, SortByDirection.DESC);
        //    }

        //    return sortBy switch
        //    {
        //        nameof(Segment.Name) => query.OrderBy(o => o.Name, sortByDirection),
        //        nameof(Segment.Division) => query.OrderBy(o => o.Division, sortByDirection),
        //        _ => query.OrderBy(o => o.AuditCreated, sortByDirection),
        //    };
        //}

        //private static IQueryable<Step> ApplySearchStepTemplateSort(IQueryable<Step> query, string? sortBy, SortByDirection sortByDirection)
        //{
        //    if (string.IsNullOrEmpty(sortBy))
        //    {
        //        query = query.OrderBy(o => o.AuditCreated, SortByDirection.DESC);
        //    }

        //    return sortBy switch
        //    {
        //        nameof(Step.Name) => query.OrderBy(o => o.Name, sortByDirection),
        //        nameof(Step.Division) => query.OrderBy(o => o.Division, sortByDirection),
        //        _ => query.OrderBy(o => o.AuditCreated, sortByDirection),
        //    };
        //}

        //private static IQueryable<Action> ApplySearchActionTemplateSort(IQueryable<Action> query, string? sortBy, SortByDirection sortByDirection)
        //{
        //    if (string.IsNullOrEmpty(sortBy))
        //    {
        //        query = query.OrderBy(o => o.AuditCreated, SortByDirection.DESC);
        //    }

        //    return sortBy switch
        //    {
        //        nameof(Action.Name) => query.OrderBy(o => o.Name, sortByDirection),
        //        nameof(Action.Division) => query.OrderBy(o => o.Division, sortByDirection),
        //        nameof(Action.ActionType) => query.OrderBy(o => o.ActionType, sortByDirection),
        //        _ => query.OrderBy(o => o.AuditCreated, sortByDirection),
        //    };
        //}

    }
}
#pragma warning restore CA1862 // Use the 'StringComparison' method overloads to perform case-insensitive string comparisons
