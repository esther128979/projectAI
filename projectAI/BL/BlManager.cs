using DAL.Api;
using BL.Api;
using Microsoft.Extensions.DependencyInjection;
using DAL;
using BL.Services;
using BL.Models;
using AutoMapper;

namespace BL
{
    public class BlManager : IBL
    {

        public IBLAgeGroup AgeGroup { get; }
        public IBLCategory Category { get; }
        public IBLCustomer Customer { get; }
        public IBLMovies Movies { get; }
        public IBLOrders Order { get; }



        public BlManager()
        {


            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<MappingProfile>();
            //});

            //IMapper mapper = config.CreateMapper();

            ServiceCollection serCollection = new ServiceCollection();


            serCollection.AddAutoMapper(typeof (MappingProfile )); 
            serCollection.AddSingleton<IDAL, DALManager>();
            serCollection.AddScoped<IBLAgeGroup, BLAgeGroupService>();
            serCollection.AddScoped<IBLCategory, BLCategoryService>();
            serCollection.AddScoped<IBLCustomer, BLCustomerService>();
            serCollection.AddScoped<IBLMovies, BLMovieService>();
            serCollection.AddScoped<IBLOrders, BLOrderService>();

            //הגדרת ספק מחלקות שרות
            ServiceProvider p = serCollection.BuildServiceProvider();

            AgeGroup = p.GetRequiredService<IBLAgeGroup>();
            Category = p.GetRequiredService<IBLCategory>();
            Customer = p.GetRequiredService<IBLCustomer>();
            Movies = p.GetRequiredService<IBLMovies>();
            Order = p.GetRequiredService<IBLOrders>();
        }
    }
}
