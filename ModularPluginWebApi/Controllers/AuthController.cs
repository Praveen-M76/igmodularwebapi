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
            if (model.Username == "Praveen" && model.Password == "7667")
            {
                return Ok(new
                {
                    message = "Login successful",
                    access = true
                });
            }

            return Unauthorized(new
            {
                message = "Invalid username or password",
                access = false
            });
        }
    }
}