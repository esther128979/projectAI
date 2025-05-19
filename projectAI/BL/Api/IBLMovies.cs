using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLMovies :IBLCrud<BLMovie>
    {
       

        Task<BLMovie> GetMovieByCategory();
        Task AddMovie(BLMovie  movie);

    }
}
