using BL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLMovies :IBLCrud<BLMovie>
    {
        Task AddMovie(BLMovie movie);
        Task UpdateMovie(BLMovie movie);
        Task DeleteMovie(int id);
        Task<List<BLMovie>> GetMoviesByAgeGroup(int age);
        Task<List<BLMovie>> GetMoviesByCategory(int blCategory);


    }
}
