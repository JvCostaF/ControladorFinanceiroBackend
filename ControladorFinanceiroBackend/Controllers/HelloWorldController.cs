using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControladorFinanceiroBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet("HelloWorld")]
        public IActionResult GetHelloWorld()
        {
            return Ok("Hello World!");
        }
    }
}
