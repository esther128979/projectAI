using Dal.Api;
using Dal.Models;
using DAL.Api;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
//using DAL.Models;


namespace Dal.Services
{
    public class CustomerService : ICustomer
    {
        mycontext db;
        public CustomerService(mycontext? m)
        {
            db = m;
        }
        //החזרת נתוני הלקוחות
        public async Task<List<Customer>> GetAll()
        {
            try
            {
                return  db.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving customers", ex);
            }
        }



        public async Task<Customer> Create(Customer customer)
        {
            try
            {
                db.Customers.Add(customer);
                await db.SaveChangesAsync();
                return customer;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating customer", ex);
            }
        }

        public async Task<Customer> Update(Customer customer)
        {
            try
            {
                db.Customers.Update(customer);
                await db.SaveChangesAsync();
                return customer;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating customer", ex);
            }
        }

        public async Task<Customer> Delete(Customer customer)
        {
            try
            {
                db.Customers.Remove(customer);
                await db.SaveChangesAsync();
                return customer;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting customer", ex);
            }
        }

        // תיקון שם המתודה, וכנראה רצית לפי מזהה:
        public async Task<List<Customer>> GetCastomerById()
        {
            throw new NotImplementedException("עדיין לא ברור מה הפונקציה אמורה לעשות בדיוק");
        }

        Task<List<Customer>> ICustomer.GetCastomerById()
        {
            throw new NotImplementedException();
        }

        Task<List<Customer>> ICrud<Customer>.GetAll()
        {
            throw new NotImplementedException();
        }

    }


}
