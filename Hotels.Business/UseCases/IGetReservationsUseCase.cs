
using Hotels.Domain.Models;

namespace Hotels.Business.UseCases
{
    public interface IGetReservationsUseCase : IUseCase<long, List<ReservationDto>>
    {
    }
}
