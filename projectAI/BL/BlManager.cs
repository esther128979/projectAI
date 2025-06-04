using DAL.Api;
using BL.Api;
using Microsoft.Extensions.DependencyInjection;
using DAL;
using BL.Services;
using BL.Models;
using AutoMapper;
using DAL.Services;
using System.Net.Http;
using BL.Profiles;

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
        public IEmailLinkManager EmailLinkManager { get; }

        public BlManager(
            string connectionString,
            IMapper mapper,
            IServiceProvider serviceProvider
        )
        {
            var serCollection = new ServiceCollection();

            serCollection.AddSingleton<IDAL, DALManager>(_ => new DALManager(connectionString,mapper));

            serCollection.AddScoped<IBLAgeGroup, BLAgeGroupService>();
            serCollection.AddScoped<IBLCategory, BLCategoryService>();
            serCollection.AddScoped<IBLUser, BLUserService>();
            serCollection.AddScoped<IBLMovies, BLMovieService>();
            serCollection.AddScoped<IBLOrders, BLOrderService>();
            serCollection.AddScoped<IEmailLinkManager, EmailLinkManager>();
            serCollection.AddSingleton(mapper); // מעביר את ה־Mapper שהוזרק

            serCollection.AddHttpClient<IEmailSender, EmailSender>();

            var provider = serCollection.BuildServiceProvider();

            AgeGroup = provider.GetRequiredService<IBLAgeGroup>();
            Category = provider.GetRequiredService<IBLCategory>();
            User = provider.GetRequiredService<IBLUser>();
            Movies = provider.GetRequiredService<IBLMovies>();
            Order = provider.GetRequiredService<IBLOrders>();
            EmailSender = provider.GetRequiredService<IEmailSender>();
            EmailLinkManager = provider.GetRequiredService<IEmailLinkManager>();
        }
    }

}
