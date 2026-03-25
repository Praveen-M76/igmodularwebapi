using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ModularPluginWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            return Ok(new
            {
                message = "Authorized access successful",
                user = User.Identity?.Name,
                time = DateTime.Now
            });
        }

        [HttpGet("parameters")]
        public IActionResult GetParameters()
        {
            return Ok(new
            {
                param1 = "Value 1",
                param2 = "Value 2",
                param3 = "Value 3"
            });
        }
    }
}