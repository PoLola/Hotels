namespace Hotels.Infrastructure.Repositories
{
    public interface IBaseRepository
    {
        Task SaveChanges();

        Task BeginTransaction();

        Task RollbackTransaction();

        Task CommitTransaction();
    }
}
