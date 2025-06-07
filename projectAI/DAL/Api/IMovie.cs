
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL.Api
{
    public interface IMovie: ICrud<Movie>
    {
        Task<List<Movie>> GetMoviesByCodeCategory(int categoryCode);
        Task<List<Movie>> GetMoviesByAgeGroup(int ageGroupCode);
        Task<Movie?> GetMovieById(int id);



    }
}
