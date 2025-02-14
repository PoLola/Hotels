namespace Hotels.Business.UseCases
{
    public interface IUseCase
    {
        Task ExecuteAsync();
    }

    public interface IUseCase<TRequest>
    {
        Task ExecuteAsync(TRequest request);
    }

    public interface IUseCaseOnlyResponse<TResponse>
    {
        Task<TResponse> ExecuteAsync();
    }

    public interface IUseCase<TRequest, TResponse>
        where TResponse : class
    {
        Task<TResponse> ExecuteAsync(TRequest request = default);
    }
}
