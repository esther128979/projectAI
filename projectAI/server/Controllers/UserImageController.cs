using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace server.Controllers
{
    [ApiController]
    [Route("DosFlix/[controller]")]
    public class UserImageController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public UserImageController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost("upload")]
        public IActionResult UploadImage([FromBody] ImageUploadDto dto)
        {
            if (string.IsNullOrEmpty(dto.ImageBase64))
                return BadRequest("Missing image");

            var base64 = dto.ImageBase64.Split(',')[1]; // מוציא את data:image/jpeg;base64,
            byte[] imageBytes = Convert.FromBase64String(base64);

            string folderPath = Path.Combine(_env.WebRootPath ?? "wwwroot", "UserImages");
            Directory.CreateDirectory(folderPath);

            string fileName = $"user_{Guid.NewGuid()}.jpg";
            string filePath = Path.Combine(folderPath, fileName);

            System.IO.File.WriteAllBytes(filePath, imageBytes);

            return Ok(new { fileName });
        }
    }

    public class ImageUploadDto
    {
        public string ImageBase64 { get; set; }
    }
}