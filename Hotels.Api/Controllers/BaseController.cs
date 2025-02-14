using Microsoft.AspNetCore.Mvc;

namespace Hotels.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public abstract class BaseController : ControllerBase
    {
    }
}
