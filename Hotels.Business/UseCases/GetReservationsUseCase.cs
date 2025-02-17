using Hotels.Business.Mapper;
using Hotels.Domain.Models;
using Hotels.Infrastructure.Repositories;

namespace Hotels.Business.UseCases
{
    public class GetReservationsUseCase(IHotelRepository _repository, IHotelMapperService _mapperService) : IGetReservationsUseCase
    {
        public async Task<List<ReservationDto>> ExecuteAsync(GetResevationRequestDto getResevationRequestDto)
        {
            try
            {
                await _repository.BeginTransaction();
                var result = await _repository.GetReservationsById(getResevationRequestDto);
                if (result is null || result.Count == 0)
                    return [];

                var resultDto = result.Select(_mapperService.MapEntityToReservationDto).ToList();
                return resultDto;
            }
            catch
            {
                await _repository.RollbackTransaction();
                throw;
            }
        }
    }
}
