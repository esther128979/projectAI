using Dal.Api;
using BL.Api;
using Microsoft.Extensions.DependencyInjection;
using Dal;
using BL.Services;
using BL.Models;
using DAL;
using DAL.Models;
using AutoMapper;

namespace BL
{
    public class BlManager : IBL
    {

        public IBLAgeGroup AgeGroup { get; }
        public IBLCategory Category { get; }
        public IBLCustomer Customer { get; }
        public IBLMovies Movies { get; }
        public IBLOrderDetails OrderDetails { get; }
        public IBLOrders Order { get; }
        public IBLPaymentMethods PaymentMethods { get; }



        public BlManager()
        {


            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<MappingProfile>();
            //});

            //IMapper mapper = config.CreateMapper();

            ServiceCollection serCollection = new ServiceCollection();


            serCollection.AddAutoMapper(typeof (MappingProfile )); 
            serCollection.AddSingleton<IDal, DalManager>();
            serCollection.AddScoped<IBLAgeGroup, BLAgeGroupService>();
            serCollection.AddScoped<IBLCategory, BLCategoryService>();
            serCollection.AddScoped<IBLCustomer, BLCustomerService>();
            serCollection.AddScoped<IBLMovies, BLMovieService>();
            serCollection.AddScoped<IBLOrderDetails, BLOrderDetailService>();
            serCollection.AddScoped<IBLOrders, BLOrderService>();
            serCollection.AddScoped<IBLPaymentMethods, BLPaymentMethodService>();

            //הגדרת ספק מחלקות שרות
            ServiceProvider p = serCollection.BuildServiceProvider();

            AgeGroup = p.GetRequiredService<IBLAgeGroup>();
            Category = p.GetRequiredService<IBLCategory>();
            Customer = p.GetRequiredService<IBLCustomer>();
            Movies = p.GetRequiredService<IBLMovies>();
            OrderDetails = p.GetRequiredService<IBLOrderDetails>();
             Order = p.GetRequiredService<IBLOrders>();
            PaymentMethods = p.GetRequiredService<IBLPaymentMethods>();
        }
    }
}
