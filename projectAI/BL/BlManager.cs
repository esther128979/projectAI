using DAL.Api;
using BL.Api;
using Microsoft.Extensions.DependencyInjection;
using DAL;
using BL.Services;
using BL.Models;
using AutoMapper;
using DAL.Services;
using System.Net.Http;

namespace BL
{
    public class BlManager : IBL
    {

        public IBLAgeGroup AgeGroup { get; }
        public IBLCategory Category { get; }
        public IBLUser User { get; }
        public IBLMovies Movies { get; }
        public IBLOrders Order { get; }
        public IEmailSender EmailSender { get; }



        public BlManager()
        {


            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            IMapper mapper = config.CreateMapper();

            ServiceCollection serCollection = new ServiceCollection();


            serCollection.AddAutoMapper(typeof (MappingProfile )); 

            serCollection.AddSingleton<IDAL, DALManager>();

            serCollection.AddScoped<IBLAgeGroup, BLAgeGroupService>();
            serCollection.AddScoped<IBLCategory, BLCategoryService>();
            serCollection.AddScoped<IBLUser, BLUserService>();
            serCollection.AddScoped<IBLMovies, BLMovieService>();
            serCollection.AddScoped<IBLOrders, BLOrderService>();
            
            serCollection.AddHttpClient<IEmailSender, EmailSender>();

            //הגדרת ספק מחלקות שרות
            ServiceProvider p = serCollection.BuildServiceProvider();

            AgeGroup = p.GetRequiredService<IBLAgeGroup>();
            Category = p.GetRequiredService<IBLCategory>();
            User = p.GetRequiredService<IBLUser>();
            Movies = p.GetRequiredService<IBLMovies>();
            Order = p.GetRequiredService<IBLOrders>();
            EmailSender = p.GetRequiredService<IEmailSender>();
        }
    }
}
