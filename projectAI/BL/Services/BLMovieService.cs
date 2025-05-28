using AutoMapper;
using BL.Api;
using BL.Models;
using DAL.Api;
using DAL.Models;
using iText.Forms.Xfdf;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BLMovieService : IBLMovies
    {

        private readonly IDAL _dal;
        private readonly IMapper _mapper;

        public BLMovieService(IDAL dal, IMapper mapper)
        {
            _dal = dal;
            _mapper = mapper;
        }
        public async Task AddMovie(BLMovie movie)
        {
            var dalMovie = _mapper.Map<Movie>(movie);
            await _dal.Movie.Create(dalMovie);
        }

        public async Task UpdateMovie(BLMovie movie)
        {
            var existingMovie = await _dal.Movie.GetMovieById(movie.Id);
            if (existingMovie == null)
                throw new Exception("Movie not found");

            _mapper.Map(movie, existingMovie);
            await _dal.Movie.Update(existingMovie);
        }

        public async Task DeleteMovie(int id)
        {
            var existingMovie = await _dal.Movie.GetMovieById(id);
            if (existingMovie == null)
                throw new Exception("Movie not found");

            await _dal.Movie.Delete(existingMovie);
        }

        public async Task<List<BLMovie>> GetAll()
        {
            var movies = await _dal.Movie.GetAll();
            return _mapper.Map<List<BLMovie>>(movies);
        }

        public async Task<List<BLMovie>> GetMoviesByAgeGroup(int age)
        {
            int ageGroupCode = (int)age;

            // קריאה ל-DAL
            var moviesDal = await _dal.Movie.GetMoviesByAgeGroup(ageGroupCode);

            // מיפוי חזרה ל-BLMovie
            return _mapper.Map<List<BLMovie>>(moviesDal);
        }

        public async Task<List<BLMovie>> GetMoviesByCategory(int category)
        {
            int categoryCode = (int)category;

            // קריאה ל-DAL
            var moviesDal = await _dal.Movie.GetMoviesByCodeCategory(categoryCode);

            // מיפוי חזרה ל-BLMovie
            return _mapper.Map<List<BLMovie>>(moviesDal);
        }
    }
}
