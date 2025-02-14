using Hotels.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotels.Infrastructure.Context
{
    public class HotelContext(DbContextOptions<HotelContext> options) : DbContext(options), IHotelContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Guest> Guests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public async Task BeginTransaction()
        {
            await Database.BeginTransactionAsync();
        }

        public async Task RollbackTransaction()
        {
            await Database.RollbackTransactionAsync();
        }

        public async Task CommitTransaction()
        {
            await Database.CommitTransactionAsync();
        }
    }
}
