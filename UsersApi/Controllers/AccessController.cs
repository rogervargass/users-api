using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UsersApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AccessController : ControllerBase
    {
        [HttpGet]
        [Authorize(Policy = "MinimumAge")]
        public IActionResult Get()
        {
            return Ok("access allowed");
        }
    }
}