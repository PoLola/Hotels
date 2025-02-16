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

        [HttpGet("rooms")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(RoomDto))]
        public async Task<IActionResult> GetRooms(
            [FromBody] GetRoomRequest request,
            [FromServices] IGetRoomUseCase useCase)
        {
            var result = await useCase.ExecuteAsync(request);
            return Ok(result);
        }
    }
}
