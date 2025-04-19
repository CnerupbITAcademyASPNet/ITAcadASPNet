using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationLab5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [Authorize]
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok(new { Message = "This is a protected endpoint!" });
        }

        [HttpGet("public")]
        public IActionResult GetPublic()
        {
            return Ok(new { Message = "This is a public!" });
        }
    }
}
