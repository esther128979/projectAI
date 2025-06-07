using AutoMapper;
using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Models;

namespace server.Controllers
{
    [Route("DosFlix/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IBL _movieService;
        private readonly IMapper _mapper;

        public MoviesController(IBL movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieGetDTO>>> GetAll()
        {
            var movies = await _movieService.Movies.GetAll();
            var dtoList = _mapper.Map<List<MovieGetDTO>>(movies);
            return Ok(dtoList);
        }

        [HttpGet("by-age/{ageGroup}")]
        public async Task<ActionResult<List<MovieGetDTO>>> GetByAgeGroup(int ageGroup)
        {
            var movies = await _movieService.Movies.GetMoviesByAgeGroup(ageGroup);
            var dtoList = _mapper.Map<List<MovieGetDTO>>(movies);
            return Ok(dtoList);
        }

        [HttpGet("by-category/{category}")]
        public async Task<ActionResult<List<MovieGetDTO>>> GetByCategory(int category)
        {
            var movies = await _movieService.Movies.GetMoviesByCategory(category);
            var dtoList = _mapper.Map<List<MovieGetDTO>>(movies);
            return Ok(dtoList);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateMovie([FromBody] MovieCreateDTO movieDto)
        {
            var blMovie = _mapper.Map<BLMovie>(movieDto);
            await _movieService.Movies.AddMovie(blMovie);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> UpdateMovie(int id, [FromBody] MovieUpdateDTO movieDto)
        {
            if (id != movieDto.Id)
                return BadRequest("ID mismatch");

            var blMovie = _mapper.Map<BLMovie>(movieDto);

            try
            {
                await _movieService.Movies.UpdateMovie(blMovie);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            try
            {
                await _movieService.Movies.DeleteMovie(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
