using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ModularPluginWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("add")]
        public IActionResult Add(int a, int b)
        {
            return Ok(new
            {
                a,
                b,
                result = a + b
            });
        }

        [HttpGet("sub")]
        public IActionResult Sub(int a, int b)
        {
            return Ok(new
            {
                a,
                b,
                result = a - b
            });
        }
    }
}