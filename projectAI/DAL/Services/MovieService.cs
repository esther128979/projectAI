using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Api;
using DAL.Models;

namespace Dal.Services
{
    public class MovieService : IMovie
    {
        public Task<Movie> Create(Movie t)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> Delete(Movie t)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> GetMovieByCodeCategory()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> Update(Movie t)
        {
            throw new NotImplementedException();
        }
    }
}
