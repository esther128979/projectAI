using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Api;
using DAL.Models;
using iText.Commons.Actions.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DAL.Services
{
    public class MovieService: IMovie
    {
        private readonly AppDbContext db;
        public MovieService(AppDbContext m)
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
        public async Task<Movie?> GetMovieById(int id)
        {
            try
            {
                return await db.Movies
                    .FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה בהחזרת סרט לפי מזהה", ex);
            }
        }

        public async Task<List<Movie>> GetMoviesByCodeCategory(int c)
        {

            try
            {
                return await db.Movies
                        .Where(m => m.CategoryCode == c)
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה בעת שליפת סרטים לפי קטגוריה", ex);
            }

        }
        public async Task<List<Movie>> GetMoviesByAgeGroup(int ageGroupCode)
        {

            try
            {
                return await db.Movies
                        .Where(m => m.AgeCode == ageGroupCode)
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה בעת שליפת סרטים לפי קבוצת גיל", ex);
            }

        }

       
    }
}
