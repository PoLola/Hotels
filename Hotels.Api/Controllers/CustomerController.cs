using Hotels.Business.UseCases;
using Hotels.Domain.Models;
using Hotels.Domain.Request;
using Hotels.Domain.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Hotels.Api.Controllers
{
    public class CustomerController : BaseController
    {

        [HttpPost("rooms")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(RoomDto))]
        public async Task<IActionResult> GetRooms(
            [FromBody] GetRoomRequest request,
            [FromServices] IGetRoomUseCase useCase)
        {
            var result = await useCase.ExecuteAsync(request);
            return Ok(result);
        }


        [HttpPost("room/{roomId}/book")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(RoomDto))]
        public async Task<IActionResult> BookRoom(
            [FromBody] BookRoomRequest request,
            [FromServices] IBookRoomUseCase useCase,
            [FromRoute] long roomId)
        {
            BookRoomRequestDto book = new BookRoomRequestDto(request, roomId);
            var result = await useCase.ExecuteAsync(book);
            return Ok(result);
        }
    }
}
