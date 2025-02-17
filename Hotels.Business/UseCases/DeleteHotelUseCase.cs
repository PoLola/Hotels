using Hotels.Business.Mapper;
using Hotels.Infrastructure.Repositories;

namespace Hotels.Business.UseCases
{
    public class DeleteHotelUseCase(IHotelRepository _repository, IHotelMapperService _mapperService) : IDeleteHotelUseCase
    {
        public async Task ExecuteAsync(long hotelId)
        {
            try
            {
                await _repository.BeginTransaction();
                var hotel = await _repository.IsHotelExists(hotelId);
                if (hotel)
                { 
                    await _repository.DeleteHotelById(hotelId);
                }
                else
                {
                    throw new Exception($"Hotel with Id:{hotelId} does not exist");
                }

                await _repository.CommitTransaction();

            }
            catch
            {
                await _repository.RollbackTransaction();
                throw;
            }
        }
    }
}
