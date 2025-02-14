using Hotels.Domain.Models;
using Hotels.Domain.Request;
using Hotels.Domain.Response;

namespace Hotels.Business.UseCases
{
    public interface ISaveRoomUseCase : IUseCase<SaveUseCaseRequestDto<SaveRoomRequest>, SaveRoomResponse>
    {
    }
}
