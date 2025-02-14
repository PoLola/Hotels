using Hotels.Business.Mapper;
using Hotels.Domain.Models;
using Hotels.Domain.Request;
using Hotels.Domain.Response;
using Hotels.Infrastructure.Repositories;

namespace Hotels.Business.UseCases
{
    public class SaveHotelUseCase(IHotelRepository _repository, IHotelMapperService _mapperService) : ISaveHotelUseCase
    {
        public async Task<SaveHotelResponse> ExecuteAsync(SaveUseCaseRequestDto<SaveHotelRequest> request)
        {
            try
            {
                long hotelId = 0;
                await _repository.BeginTransaction();
                var isNew = !(request.Id.HasValue && request.Id.Value > 0);

                if (isNew)
                {
                    var hotel = _mapperService.MapToHotelEntity(request.Data);
                    hotelId = await _repository.CreateHotel(hotel);
                }
                else
                {
                    var hotel = await _repository.GetHotelById(request.Id.Value) ?? throw new Exception($"Hotel with Id:{request.Id} does not exist");
                    var updatedHotel = _mapperService.MapToHotelEntity(request.Data, entity: hotel);
                    await _repository.SaveChanges();
                    hotelId = updatedHotel.Id;
                }

                await _repository.CommitTransaction();

                return new SaveHotelResponse { HotelId = hotelId };
            }
            catch
            {
                await _repository.RollbackTransaction();
                throw;
            }
        }
    }
}
