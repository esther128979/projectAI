using AutoMapper;
using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Mvc;
using server.Models;

namespace server.Controllers
{
    [Route("DosFlix/[controller]")]
    [ApiController]
    public class EmailLinkController : ControllerBase
    {
        private readonly IBL _bl;

        public EmailLinkController(IBL bl)
        {
            _bl=bl;
        }

        [HttpGet("track")]
        public async Task<IActionResult> TrackEmailClick([FromQuery] string token)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown IP";
            var userAgent = Request.Headers["User-Agent"].ToString();

            var result = await _bl.EmailLinkManager.TrackClickAsync(token, ip, userAgent);

            if (!result.IsSuccess)
            {
                return BadRequest(new { message = result.Error });
            }

            return Redirect(result.Value); // הפנייה לסרט
        }



    }
}
