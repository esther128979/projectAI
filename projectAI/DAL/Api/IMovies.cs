using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Api
{
   public interface IMovies: ICrud<Movie>
    {
        Task<List<Movie>> GetByCategory(int categoryCode);
        Task<List<Movie>> GetByAgeGroup(int AgeCode);


    }
}
