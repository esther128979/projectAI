using AutoMapper;
using BL.Api;
using BL.Models;
using DAL.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BLMovieService : IBLMovies
    {

        IDAL dal;
        IMapper mapper;
        public BLMovieService(IDAL d, IMapper mapper)
        {
            dal = d;
            
            this.mapper = mapper;
        }

       public  async Task AddMovie(BLMovie movie)
        {
            throw new NotImplementedException();
           //await dal.Movie.Create(mapper.Map<DAL.Models.Movie>(movie));
        }

        public async Task<List<BLMovie>> GetAll()
        {
            List<BLMovie> list = new List<BLMovie>();

            //var dallist = dal.Movie.GetAll().Result;

            //dallist.ForEach(l=>list.Add( mapper.Map<BLMovie >(l)));

            return list;
        }

        public async Task<BLMovie> GetMovieByCategory()
        {

            throw new NotImplementedException();
        }
    }
}
