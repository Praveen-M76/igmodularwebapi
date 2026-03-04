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
            var plugins = new[]
            {
                "Plugin DLL1",
                "Plugin DLL2"
            };

            return Ok(plugins);
        }
    }
}