using Hotels.Business.Mapper;
using Hotels.Domain.Entities;
using Hotels.Domain.Models;
using Hotels.Domain.Request;
using Hotels.Domain.Response;
using Hotels.Infrastructure.Repositories;

namespace Hotels.Business.UseCases
{
    public class SaveRoomUseCase(IHotelRepository _repository, IHotelMapperService _mapperService) : ISaveRoomUseCase
    {
        public async Task<SaveRoomResponse> ExecuteAsync(SaveUseCaseRequestDto<SaveRoomRequest> request)
        {
            try
            {
                long roomId = 0;
                await _repository.BeginTransaction();
                if (!await _repository.IsHotelExists(request.ParentId.Value))
                    throw new Exception($"Hotel with Id:{request.ParentId} does not exist");

                var isNew = !(request.Id.HasValue && request.Id.Value > 0);

                if (isNew)
                {
                    var room = _mapperService.MapToRoomEntity(request.Data, request.ParentId.Value);
                    roomId = await _repository.CreateRoom(room);
                }
                else
                {
                    var room = await _repository.GetRoomById(request.Id.Value) ?? throw new Exception($"Room with Id:{request.Id} does not exist");
                    var updatedRoom = _mapperService.MapToRoomEntity(request.Data, entity: room);
                    await _repository.SaveChanges();
                }

                await _repository.CommitTransaction();

                return new SaveRoomResponse { RoomId = roomId };
            }
            catch
            {
                await _repository.RollbackTransaction();
                throw;
            }
        }
    }
}
