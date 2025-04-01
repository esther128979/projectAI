using Dal.Models;
using DAL.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace DAL.Services
{
    internal class MoviesService : IMovies
    {
        mycontext db;
        public MoviesService(mycontext? m)
        {
            db = m;
        }
        public async Task<List<Movie>> GetAll()
        {
            try
            {
                return db.Movies.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving Movies", ex);

            }
        }
        public async Task<List<Movie>> GetByCategory(int categoryCode)
        {
            try
            {
                return db.Movies.Where(m => m.CodeCategory == categoryCode).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving Movies by category: {categoryCode} id", ex);

            }
        }
        public async Task<List<Movie>> GetByAgeGroup(int AgeCode)
        {
            try
            {
                return db.Movies.Where(m => m.AgeCode == AgeCode).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving Movies by category: {AgeCode} id", ex);

            }
        }
    }
}
