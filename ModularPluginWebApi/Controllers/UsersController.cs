using Microsoft.AspNetCore.Mvc;

namespace ModularPluginWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet("getusers")]
        public IActionResult GetUsers()
        {
            var users = new[]
            {
                new { Id = 1, Name = "Naveen" },
                new { Id = 2, Name = "Kumar" },
                new { Id = 3, Name = "Arun" }
            };

            return Ok(users);
        }
    }
}