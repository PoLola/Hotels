
using Hotels.Domain.Models;

namespace Hotels.Business.UseCases
{
    public interface IGetRoomUseCase : IUseCase<GetResevationRequestDto, List<ReservationDto>>
    {
    }
}
