
using Hotels.Domain.Models;

namespace Hotels.Business.UseCases
{
    public interface IGetReservationsUseCase : IUseCase<GetResevationRequestDto, List<ReservationDto>>
    {
    }
}
