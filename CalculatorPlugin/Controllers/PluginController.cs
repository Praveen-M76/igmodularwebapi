using Microsoft.AspNetCore.Mvc;

namespace ModularPluginWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PluginController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPlugins()
        {
            return Ok("Plugin API is working");
        }

        [HttpGet("status")]
        public IActionResult Status()
        {
            return Ok("Plugin system active");
        }
    }
}