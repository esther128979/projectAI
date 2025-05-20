using BL.Api;
using BL.Models;
using BL.Services;
using Microsoft.AspNetCore.Mvc;


namespace Server.Controllers
{
    [Route("DosFlix/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IBLMovies _movieService;

        public MoviesController(IBLMovies movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BLMovie>>> Get()
        {
            var movies = await _movieService.GetAll();
            return Ok(movies);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BLMovie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _movieService.AddMovie(movie);
            return Ok();
        }
    }
}