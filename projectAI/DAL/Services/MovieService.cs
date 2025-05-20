using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Api;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Services
{
    public class MovieService : IMovie
    {
        private readonly mycontext db;
        public MovieService(mycontext m)
        {
            db = m;
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
                var movie = await db.Movies.FindAsync(t.Id);
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

        public async Task<List<Movie>> GetMovieByCodeCategory(Category c)
        {

            try
            {
                return await db.Movies
                    .Where(m => m.CodeCategory == c.CategoryCode)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה בעת שליפת סרטים לפי קטגוריה", ex);
            }
            
        }

       
    }
}
