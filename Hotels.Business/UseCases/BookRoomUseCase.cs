using Hotels.Business.Mapper;
using Hotels.Domain.Entities;
using Hotels.Domain.Models;
using Hotels.Domain.Request;
using Hotels.Domain.Response;
using Hotels.Infrastructure.Repositories;

namespace Hotels.Business.UseCases
{
    public class BookRoomUseCase(IHotelRepository _repository, IHotelMapperService _mapperService) : IBookRoomUseCase
    {
        public async Task<BookRoomResponse> ExecuteAsync(BookRoomRequestDto bookRoomRequestDto)
        {
            try
            {
                await _repository.BeginTransaction();
                Reservation reservation = _mapperService.MapBookRoomToReservation(bookRoomRequestDto);
                long reservationId = await _repository.BookRoom(reservation);
                BookRoomResponse bookRoomResponse = new BookRoomResponse(reservationId, bookRoomRequestDto.Data);
                await _repository.SendEmailConfirmation(bookRoomResponse);
                await _repository.CommitTransaction();
                return bookRoomResponse;
            }
            catch
            {
                await _repository.RollbackTransaction();
                throw;
            }
        }
    }
}
