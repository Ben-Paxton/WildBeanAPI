using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using WildBeanAPI.Models;
using WildBeanAPI.Utils;

namespace WildBeanAPI.Controllers
{
    [Route("api/coffee")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        // GET: api/Coffee/<brew-coffee>
        [HttpGet("brew-coffee")]
        [EnableRateLimiting("ratePolicy")]
        public IActionResult Get()
        {
            var result = StatusCode(404, null);

            try {
                if (string.Equals(DateTimeProvider.Now.ToString("dd-MM"), "01-04"))
                {
                    result = StatusCode(418, null);
                }
                else
                {
                    result = StatusCode(200, new CoffeeModel { Message = "Your piping hot coffee is ready", Prepared = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssK") });
                }
            } catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }
    }
}
