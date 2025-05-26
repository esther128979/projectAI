using DAL.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using DAL.Services;
namespace DAL;

public class DALManager : IDAL
{
    public ICustomer Customer { get; }
    public IOrder Order { get; }

    public ICategory Category { get; }
 
    public IMovie Movie { get; }
    public IEmailLink EmailLink { get;  }
    public IEmailLinkClick EmailLinkClick { get;  }
    public IUser User { get;  }


    //public IAgeGruop AgeGruop { get; }

    public DALManager(string connectionString)
    {
        ServiceCollection serCollection = new ServiceCollection();
        serCollection.AddDbContext<AppDbContext>(options =>
         options.UseSqlServer(connectionString));

        serCollection.AddSingleton<AppDbContext>();

        serCollection.AddScoped<ICustomer, CustomerService>();
        serCollection.AddScoped<IOrder, OrderService>();
        serCollection.AddScoped<IMovie, MovieService>();
        serCollection.AddScoped<ICategory, CategoryService>();
        serCollection.AddScoped<IEmailLink, EmailLinkService>();
        serCollection.AddScoped<IEmailLinkClick, EmailLinkClickService>();
        serCollection.AddScoped<IUser, UserService>();

        // הגדרת ספק מחלקות שרות
        ServiceProvider p = serCollection.BuildServiceProvider();
        Customer = p.GetRequiredService<ICustomer>();
        Order = p.GetRequiredService<IOrder>();
        Movie = p.GetRequiredService<IMovie>();
        Category = p.GetRequiredService<ICategory>();
        EmailLink = p.GetRequiredService<IEmailLink>();
        EmailLinkClick = p.GetRequiredService<IEmailLinkClick>();
        User = p.GetRequiredService<IUser>();



    }
}
