using Hotels.Infrastructure.Context;

namespace Hotels.Infrastructure.Repositories
{
    public abstract class BaseRepository(IHotelContext _context) : IBaseRepository
    {
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task BeginTransaction()
        {
            await _context.BeginTransaction();
        }

        public async Task RollbackTransaction()
        {
            await _context.RollbackTransaction();
        }

        public async Task CommitTransaction()
        {
            await _context.CommitTransaction();
        }
    }
}
