using Hotels.Business.UseCases;
using Hotels.Domain.Models;
using Hotels.Domain.Request;
using Hotels.Domain.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Hotels.Api.Controllers
{
    public class AgencyController : BaseController
    {
        [HttpPut("hotel/{hotelId?}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SaveHotelResponse))]
        public async Task<IActionResult> SaveHotel(
            [FromBody] SaveHotelRequest request,
            [FromServices] ISaveHotelUseCase useCase,
            [FromRoute] long? hotelId = null)
        {
            var requestUseCase = new SaveUseCaseRequestDto<SaveHotelRequest>
            {
                Id = hotelId,
                Data = request,
            };
            var result = await useCase.ExecuteAsync(requestUseCase);
            return Ok(result);
        }

        [HttpPut("hotel/{hotelId}/room/{roomId?}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SaveRoomResponse))]
        public async Task<IActionResult> SaveRoom(
            [FromBody] SaveRoomRequest request,
            [FromServices] ISaveRoomUseCase useCase,
            [FromRoute] long hotelId,
            [FromRoute] long? roomId = null)
        {
            var requestUseCase = new SaveUseCaseRequestDto<SaveRoomRequest>
            {
                Id = roomId,
                ParentId = hotelId,
                Data = request,
            };
            var result = await useCase.ExecuteAsync(requestUseCase);
            return Ok(result);
        }

        [HttpPut("{agencyId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SaveRoomResponse))]
        public async Task<IActionResult> GetReservations(
            [FromServices] IGetReservationsUseCase useCase,
            [FromRoute] long agencyId)
        {
            var result = await useCase.ExecuteAsync(agencyId);
            return Ok(result);
        }
    }
}
