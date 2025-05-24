
using DAL.Models;


namespace DAL.Api
{
    public interface ICustomer : ICrud<Customer>
    {
        Task<Customer> GetCustomerById( int id);
    }
}
