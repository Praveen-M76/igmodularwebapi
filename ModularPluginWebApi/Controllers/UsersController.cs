using Microsoft.AspNetCore.Mvc;

namespace ModularPluginWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // GET: /api/Users/getusers
        [HttpGet("getusers")]
        public IActionResult GetUsers()
        {
            var users = new string[]
            {
                "Naveen",
                "Arun",
                "Kumar",
                "Siva"
            };

            return Ok(users);
        }

        // GET: /api/Users/count
        [HttpGet("count")]
        public IActionResult GetUserCount()
        {
            return Ok(new { Count = 4 });
        }
    }
}