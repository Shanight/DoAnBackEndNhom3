using Microsoft.AspNetCore.Mvc;

namespace MyBGList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ErrorController : ControllerBase
    {
        [HttpGet("error")]
        public IActionResult Error()
        {
            return Problem();
        }

        [HttpGet("error/test")]
        public IActionResult Test()
        {
            throw new Exception("test");
        }
    }
}
