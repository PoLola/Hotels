
using Hotels.Domain.Request;
using Hotels.Domain.Response;

namespace Hotels.Business.UseCases
{
    public interface IGetRoomUseCase : IUseCase<GetRoomRequest, List<GetRoomResponse>>
    {
    }
}
