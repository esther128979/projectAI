using Dal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using Dal.Services;
using DAL.Api;
using DAL.Models;
using DAL.Services;
namespace Dal;

public class DalManager : IDal
{
    public ICustomer Customer { get; }
    public IOrder Order { get; }

    public ICategory Category { get; }
 
    public IMovie Movie { get; }

    public IAgeGruop AgeGruop { get; }

    public DalManager()
    {
        ServiceCollection serCollection = new ServiceCollection();
        serCollection.AddDbContext<mycontext>(options =>
         options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\214991887\\Desktop\\projectAI\\projectAI\\adminScreen_DB.mdf;Integrated Security=True;Connect Timeout=30"));

        serCollection.AddSingleton<mycontext>();

        serCollection.AddScoped<IDal, DalManager>();//צריך לבדוק!!!
        serCollection.AddScoped<ICustomer, CustomerService>();
        serCollection.AddScoped<IOrder, OrderService>();
        serCollection.AddScoped<IMovie, MovieService>();
        serCollection.AddScoped<ICategory, CategoryService>();
        serCollection.AddScoped<IAgeGruop, AgeGruopService>();

        // הגדרת ספק מחלקות שרות
        ServiceProvider p = serCollection.BuildServiceProvider();
        Customer = p.GetRequiredService<ICustomer>();
        Order = p.GetRequiredService<IOrder>();
        Movie= p.GetRequiredService<IMovie>();  
        Category = p.GetRequiredService<ICategory>();
        AgeGruop=p.GetRequiredService<IAgeGruop>();
     
      

    }
}
