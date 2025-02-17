
using Hotels.Domain.Models;
using Hotels.Domain.Response;

namespace Hotels.Business.UseCases
{
    public interface IBookRoomUseCase : IUseCase<BookRoomRequestDto, BookRoomResponse>
    {
    }
}
