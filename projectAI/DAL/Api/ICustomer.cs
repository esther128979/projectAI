using Dal.Models;


namespace Dal.Api
{
    public interface ICustomer : ICrud<Customer>
    {
        Task<List<Customer>> GetCastomerById();
    }
}
