using Hotels.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotels.Infrastructure.Context
{
    public interface IHotelContext
    {
        DbSet<Hotel> Hotels { get; set; }
        DbSet<Room> Rooms { get; set; }
        DbSet<Reservation> Reservations { get; set; }
        DbSet<Guest> Guests { get; set; }

        // Methods
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        Task BeginTransaction();

        Task RollbackTransaction();

        Task CommitTransaction();
    }
}
