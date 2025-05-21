using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Server.Controllers
{
    [Route("DosFlix/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public OrderController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost("submit-order")]
        public async Task<IActionResult> SubmitOrder([FromBody] OrderData order)
        {
            var googleScriptUrl = "https://script.google.com/macros/s/AKfycbx_gt_DpSyUKHThKe_bwT4dkfiENMRr7aQnNtvXKiO9KHAX7LmCzE05ZalGuRJOVbA7/exec";
            var formContent = new FormUrlEncodedContent(new[]
            {
        new KeyValuePair<string, string>("email", order.Email),
        new KeyValuePair<string, string>("movieName", order.MovieName),
    });

            try
            {
                var response = await _httpClient.PostAsync(googleScriptUrl, formContent);
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return Ok(new { success = true, message = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "שגיאה ב-Google Script", details = result });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "שגיאת מערכת", error = ex.Message });
            }
        }

        public class OrderData
        {
            public string Email { get; set; }
            public string MovieName { get; set; }

        }
    }

}