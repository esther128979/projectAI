using Dal.Api;
using DAL.Models;


namespace DAL.Api
{
    public interface ICustomer : ICrud<Customer>
    {
        Task<List<Customer>> GetCastomerById();
    }
}
