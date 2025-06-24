
using DAL.Models;


namespace DAL.Api
{
    public interface ICustomer : ICrud<Customer>
    {
        Task<Customer> GetCustomerById( int id);
        Task<Customer?> GetCustomerByEmail(string email);
        Task<List<Customer>> GetCustomersByPhone(string phone); // אם השדה הוא string
        Task<List<Customer>> GetCustomersByGender(string gender);
        Task<List<Customer>> GetCustomersByAgeGroup(int ageGroup);

    }
}
