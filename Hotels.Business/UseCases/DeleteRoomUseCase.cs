using Azure.Core;
using Hotels.Business.Mapper;
using Hotels.Domain.Models;
using Hotels.Domain.Request;
using Hotels.Domain.Response;
using Hotels.Infrastructure.Repositories;

namespace Hotels.Business.UseCases
{
    public class DeleteRoomUseCase(IHotelRepository _repository, IHotelMapperService _mapperService) : IDeleteRoomUseCase
    {
        public async Task ExecuteAsync(long roomId)
        {
            try
            {
                await _repository.BeginTransaction();
                var Room = await _repository.IsRoomExists(roomId);
                if (Room)
                { 
                    await _repository.DeleteRoomById(roomId);
                }
                else
                {
                    throw new Exception($"Room with Id:{roomId} does not exist");
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
