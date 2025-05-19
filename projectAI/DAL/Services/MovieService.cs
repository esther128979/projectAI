using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Api;
using Dal.Models;
using DAL.Models;

namespace Dal.Services
{
    public class MovieService : IMovie
    {

        mycontext db;

        public MovieService(mycontext db)
        {

        this.db = db; 
        }
    
        public async Task<Movie> Create(Movie t)
        {
            try
            {
                db.Movies.Add(t);
                await db.SaveChangesAsync();
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating Movie", ex);
            }
        }

        public async Task<Movie> Delete(Movie t)
        {
            try
            {
                var movie = await db.Movies.FindAsync(movie.Id);
                if (movie == null)
                {
                    return null;
                }

                db.Movies.Remove(movie);
                await db.SaveChangesAsync();
                return movie;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Deleteing Movie", ex);
            }
        }

        public async Task<Movie> Update(Movie movie)
        {
            try
            {
                db.Movies.Update(movie);
                await db.SaveChangesAsync();
                return movie;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating movie", ex);
            }
        }

        public async Task<List<Movie>> GetAll()
        {
            try
            {
                return await db.Movies.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving movie data", ex);
            }
        }

        public Task<List<Movie>> GetMovieByCodeCategory()
        {
            throw new NotImplementedException();
        }

       
    }
}
