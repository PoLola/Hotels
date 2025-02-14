namespace Hotels.Domain.Models
{
    public record SaveUseCaseRequestDto<TRequest>
    {
        public long? Id { get; set; }
        public long? ParentId { get; set; }
        public TRequest Data { get; set; }
    };
}
