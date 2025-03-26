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
namespace Dal
{
    public class DalManager : IDal
    {
        public ICustomer Customer { get; }
        public IOrder Order { get; }

        public DalManager()
        {
            ServiceCollection serCollection = new ServiceCollection();
            serCollection.AddDbContext<mycontext>(options =>
             options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\לימודים\\פרויקט גמר\\OrderManagementSystem\\adminScreen_DB.mdf\";Integrated Security=True;Connect Timeout=30"));

            serCollection.AddSingleton<mycontext>();
            serCollection.AddScoped<ICustomer, CustomerService>();
            serCollection.AddScoped<IOrder, OrderService>();

            // הגדרת ספק מחלקות שרות
            ServiceProvider p = serCollection.BuildServiceProvider();
            Customer = p.GetRequiredService<ICustomer>();
            Order = p.GetRequiredService<IOrder>();

        }
    }
}
