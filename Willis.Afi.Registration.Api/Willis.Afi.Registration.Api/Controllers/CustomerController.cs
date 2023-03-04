using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Willis.Afi.Registration.Api.Models;

namespace Willis.Afi.Registration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RegisterResponse> Register(RegisterRequest request)
        {
            return new RegisterResponse();
        }

    }
}
