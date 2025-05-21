using DAL.Api;
using DAL.Models;
using Microsoft.EntityFrameworkCore;



namespace DAL.Services
{
    public class CustomerService : ICustomer
    {
        AppDbContext db;
        public CustomerService(AppDbContext? m)
        {
            db = m;
        }
        //החזרת נתוני הלקוחות
        public async Task<List<Customer>> GetAll()
        {
            try
            {
                return await db.Customers.ToListAsync();
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




        public async Task<Customer?> GetCustomerById(int id)
        {
            try
            {
                return await db.Customers
                    .FirstOrDefaultAsync(c => c.UserId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה בהחזרת לקוח לפי מזהה", ex);
            }
        }





    }


}
