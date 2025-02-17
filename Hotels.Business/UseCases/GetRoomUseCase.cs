using Hotels.Business.Mapper;
using Hotels.Domain.Entities;
using Hotels.Domain.Request;
using Hotels.Domain.Response;
using Hotels.Infrastructure.Repositories;

namespace Hotels.Business.UseCases
{
    public class GetRoomUseCase(IHotelRepository _repository, IHotelMapperService _mapperService) : IGetRoomUseCase
    {
        public async Task<List<GetRoomResponse>> ExecuteAsync(GetRoomRequest getRoomRequest)
        {
            try
            {
                await _repository.BeginTransaction();
                List<Hotel> searchResult = await _repository.SearchRooms(getRoomRequest);
                if (searchResult is null || searchResult.Count == 0) return [];
                List<GetRoomResponse> results = searchResult.Select(_mapperService.MapHotelToGetRoomsResponse).ToList();
                return results;
            }
            catch
            {
                await _repository.RollbackTransaction();
                throw;
            }
        }
    }
}
