using Microsoft.AspNetCore.Mvc;
using ModularPluginWebApi.Models;

namespace ModularPluginWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (model.Username == "admin" && model.Password == "1234")
            {
                return Ok(new { message = "Login Successful" });
            }

            return Unauthorized(new { message = "Invalid Username or Password" });
        }
    }
}