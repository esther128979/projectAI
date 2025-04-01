using Dal.Api;
using Dal.Models;


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
        public async Task<Customer> GetById(int id)
        {
            try
            {
                var existCustomer = await db.Customers.FindAsync(id);

                if (existCustomer == null)
                {
                    throw new Exception("Customer not found");
                }

                return existCustomer;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

    }


}
