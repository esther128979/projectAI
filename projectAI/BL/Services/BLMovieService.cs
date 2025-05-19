using AutoMapper;
using BL.Api;
using BL.Models;
using Dal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BLMovieService : IBLMovies
    {

        IDal dal;
        IMapper mapper;
        public BLMovieService(IDal d)
        {
            dal = d;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

             mapper = config.CreateMapper();
        }

        public Task<List<BLMovie>> GetAll()
        {
            List<BLMovie> list = new List<BLMovie>();

            var dallist = dal.Movie.GetAll().Result;

            dallist.ForEach(l=>list.Add( mapper.Map<BLMovie >(l)));

            return list;
        }

        public Task<BLMovie> GetMovieByCategory()
        {
            throw new NotImplementedException();
        }
    }
}
